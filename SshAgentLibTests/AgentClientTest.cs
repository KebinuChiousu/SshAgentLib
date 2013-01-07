﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using dlech.SshAgentLib;
using System.IO;
using System.Collections.ObjectModel;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Asn1;
using System.Security.Cryptography;

namespace dlech.SshAgentLibTests
{
  [TestFixture()]
  public class AgentClientTest
  {

    private static SshKey mRsa1Key, mRsaKey, mDsaKey,
      mEcdsa256Key, mEcdsa384Key, mEcdsa521Key;
    private static ReadOnlyCollection<SshKey> mAllKeys;

    private class TestAgentClient : AgentClient
    {
      public Agent Agent { get; private set; }

      public TestAgentClient()
      {
        Agent = new TestAgent();
      }

      public override byte[] SendMessage(byte[] aMessage)
      {
        var buffer = new byte[4096];
        Array.Copy(aMessage, buffer, aMessage.Length);
        var messageStream = new MemoryStream(buffer);
        Agent.AnswerMessage(messageStream);
        var reply = new byte[messageStream.Position];
        Array.Copy(buffer, reply, reply.Length);
        return reply;
      }
    }

    private class TestAgent : Agent
    {
      public override void Dispose() { }
    }

    static AgentClientTest()
    {
      mRsa1Key = KeyGenerator.CreateKey(SshVersion.SSH1,
        PublicKeyAlgorithm.SSH_RSA, "SSH1 RSA test key");
      mRsaKey = KeyGenerator.CreateKey(SshVersion.SSH2,
     PublicKeyAlgorithm.SSH_RSA, "SSH2 RSA test key");
      mDsaKey = KeyGenerator.CreateKey(SshVersion.SSH2,
      PublicKeyAlgorithm.SSH_DSS, "SSH2 DSA test key");
      mEcdsa256Key = KeyGenerator.CreateKey(SshVersion.SSH2,
      PublicKeyAlgorithm.ECDSA_SHA2_NISTP256, "SSH2 ECDSA 256 test key");
      mEcdsa384Key = KeyGenerator.CreateKey(SshVersion.SSH2,
       PublicKeyAlgorithm.ECDSA_SHA2_NISTP384, "SSH2 ECDSA 384 test key");
      mEcdsa521Key = KeyGenerator.CreateKey(SshVersion.SSH2,
       PublicKeyAlgorithm.ECDSA_SHA2_NISTP521, "SSH2 ECDSA 521 test key");

      List<SshKey> keyList = new List<SshKey>();
      keyList.Add(mRsa1Key);
      keyList.Add(mRsaKey);
      keyList.Add(mDsaKey);
      keyList.Add(mEcdsa256Key);
      keyList.Add(mEcdsa384Key);
      keyList.Add(mEcdsa521Key);
      mAllKeys = keyList.AsReadOnly();
    }

    [Test()]
    public void TestAddConstrainedKey()
    {
      var agentClient = new TestAgentClient();
      agentClient.Agent.ConfirmUserPermissionCallback =
        delegate(ISshKey aKey) { return true; };
      Agent.KeyConstraint constraint;
      List<Agent.KeyConstraint> constraints = new List<Agent.KeyConstraint>();

      constraint = new Agent.KeyConstraint();
      constraint.Type = Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_CONFIRM;
      constraints.Add(constraint);
      agentClient.AddKey(mRsaKey, constraints);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(1));
      Assert.That(agentClient.Agent.GetAllKeys().First().Constraints.Count,
        Is.EqualTo(1));
      Assert.That(agentClient.Agent.GetAllKeys().First().Constraints.First().Type,
        Is.EqualTo(Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_CONFIRM));

      constraint = new Agent.KeyConstraint();
      constraint.Type = Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_LIFETIME;
      constraint.Data = (uint)10;
      constraints.Clear();
      constraints.Add(constraint);
      agentClient.AddKey(mRsaKey, constraints);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(1));
      Assert.That(agentClient.Agent.GetAllKeys().First().Constraints.Count,
        Is.EqualTo(1));
      Assert.That(agentClient.Agent.GetAllKeys().First().Constraints.First().Type,
        Is.EqualTo(Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_LIFETIME));
    }

    [Test()]
    public void TestAddKey()
    {
      var agentClient = new TestAgentClient();
      int keyCount = 0;

      foreach (var key in mAllKeys) {
        agentClient.AddKey(key);
        keyCount += 1;
        Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(keyCount));
        Assert.That(agentClient.Agent.GetAllKeys()
           .Get(key.Version, key.GetPublicKeyBlob()), Is.Not.Null);
      }
    }

    [Test()]
    public void TesListKeys()
    {
      var agentClient = new TestAgentClient();
      ICollection<ISshKey> keyList;

      foreach (var key in mAllKeys) {
        agentClient.Agent.AddKey(key);
      }

      // check that SS1 keys worked
      keyList = agentClient.ListKeys(SshVersion.SSH1);
      var expectedKeyList = mAllKeys.Where(key => key.Version == SshVersion.SSH1);
      Assert.That(keyList.Count, Is.EqualTo(expectedKeyList.Count()));
      foreach (var key in expectedKeyList) {
        Assert.That(keyList.Get(key.Version, key.GetPublicKeyBlob()), Is.Not.Null);
      }

      // check that ssh2 keys worked
      keyList = agentClient.ListKeys(SshVersion.SSH2);
      expectedKeyList = mAllKeys.Where(key => key.Version == SshVersion.SSH2);
      Assert.That(keyList.Count, Is.EqualTo(expectedKeyList.Count()));
      foreach (var key in expectedKeyList) {
        Assert.That(keyList.Get(key.Version, key.GetPublicKeyBlob()), Is.Not.Null);
      }
    }

    [Test()]
    public void TestRemoveAllKeys()
    {
      var agentClient = new TestAgentClient();

      /* test SSH1 */
      agentClient.Agent.AddKey(mRsa1Key);
      agentClient.Agent.AddKey(mRsaKey);
      agentClient.RemoveAllKeys(SshVersion.SSH1);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(1));

      /* test SSH2 */
      agentClient.Agent.AddKey(mRsa1Key);
      agentClient.Agent.AddKey(mRsaKey);
      agentClient.RemoveAllKeys(SshVersion.SSH2);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(1));

      /* test remove *all* keys */
      agentClient.Agent.AddKey(mRsa1Key);
      agentClient.Agent.AddKey(mRsaKey);
      agentClient.RemoveAllKeys();
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(0));
    }

    [Test()]
    public void TestRemoveKey()
    {
      var agentClient = new TestAgentClient();

      /* test SSH1 */
      agentClient.Agent.AddKey(mRsa1Key);
      agentClient.RemoveKey(mRsa1Key);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(0));

      /* test SSH2 */
      agentClient.Agent.AddKey(mRsaKey);
      agentClient.RemoveKey(mRsaKey);
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(0));

      /* test key not found */
      agentClient.Agent.AddKey(mRsaKey);
      Assert.That(() => agentClient.RemoveKey(mDsaKey),
        Throws.TypeOf<AgentFailureException>());
      Assert.That(agentClient.Agent.KeyCount, Is.EqualTo(1));
    }

    [Test()]
    public void TestSignRequest()
    {
      var passphrase = Encoding.UTF8.GetBytes("passphrase");
      var agentClient = new TestAgentClient();
      var data = Encoding.UTF8.GetBytes("Data to be signed");

      foreach (var key in mAllKeys) {
        agentClient.Agent.AddKey(key);
        var signature = agentClient.SignRequest(key, data);
        switch (key.Version) {
          case SshVersion.SSH1:
            using (MD5 md5 = MD5.Create()) {
              var md5Buffer = new byte[48];
              data.CopyTo(md5Buffer, 0);
              agentClient.SessionId.CopyTo(md5Buffer, 32);
              var expctedSignature = md5.ComputeHash(md5Buffer);
              Assert.That(signature, Is.EqualTo(expctedSignature));
            }
            break;
          case SshVersion.SSH2:
            BlobParser signatureParser = new BlobParser(signature);
            var algorithm = signatureParser.ReadString();
            Assert.That(algorithm, Is.EqualTo(key.Algorithm.GetIdentifierString()));
            signature = signatureParser.ReadBlob().Data;
            if (key.Algorithm == PublicKeyAlgorithm.SSH_RSA) {
              Assert.That(signature.Length == key.Size / 8);
            } else if (key.Algorithm == PublicKeyAlgorithm.SSH_DSS) {
              Assert.That(signature.Length, Is.EqualTo(40));
              var r = new BigInteger(1, signature, 0, 20);
              var s = new BigInteger(1, signature, 20, 20);
              var seq = new DerSequence(new DerInteger(r), new DerInteger(s));
              signature = seq.GetDerEncoded();
            } else if (key.Algorithm == PublicKeyAlgorithm.ECDSA_SHA2_NISTP256 ||
              key.Algorithm == PublicKeyAlgorithm.ECDSA_SHA2_NISTP384 ||
              key.Algorithm == PublicKeyAlgorithm.ECDSA_SHA2_NISTP521) {
              Assert.That(signature.Length, Is.AtLeast(key.Size / 4 + 8));
              Assert.That(signature.Length, Is.AtMost(key.Size / 4 + 10));
              BlobParser parser = new BlobParser(signature);
              var r = new BigInteger(parser.ReadBlob().Data);
              var s = new BigInteger(parser.ReadBlob().Data);
              var seq = new DerSequence(new DerInteger(r), new DerInteger(s));
              signature = seq.GetDerEncoded();
            }
            var signer = key.GetSigner();
            signer.Init(false, key.GetPublicKeyParameters());
            signer.BlockUpdate(data, 0, data.Length);
            var valid = signer.VerifySignature(signature);
            Assert.That(valid, Is.True);
            break;
          default:
            Assert.Fail("Unexpected Ssh Version");
            break;
        }
      }
    }

    [Test()]
    public void TestLockUnlock()
    {
      var passphrase = Encoding.UTF8.GetBytes("passphrase");
      var agentClient = new TestAgentClient();

      /* verify that locking works */
      Assert.That(() => agentClient.Lock(passphrase),
        Throws.Nothing);

      /* verify that locking already locked agent fails */
      Assert.That(() => agentClient.Lock(passphrase),
        Throws.Exception.TypeOf<AgentFailureException>());

      /* verify that unlocking works */
      Assert.That(() => agentClient.Unlock(passphrase),
        Throws.Nothing);

      /* verify that unlocking already unlocked agent fails */
      Assert.That(() => agentClient.Unlock(passphrase),
        Throws.Exception.TypeOf<AgentFailureException>());

      /* try with null passphrase */
      Assert.That(() => agentClient.Lock(null),
        Throws.Nothing);
      Assert.That(() => agentClient.Unlock(null),
        Throws.Nothing);

      /* verify that bad passphrase fails */
      Assert.That(() => agentClient.Lock(passphrase),
        Throws.Nothing);
      Assert.That(() => agentClient.Unlock(null),
        Throws.Exception.TypeOf<AgentFailureException>());
    }

  }
}