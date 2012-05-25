﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Math;

namespace dlech.PageantSharp
{
	/// <summary>
	/// used to build blobs that are used for storing and sending keys in PuTTY format
	/// </summary>
	public class PpkKeyBlobBuilder 
	{
		private List<byte> byteList;

		/// <summary>
		/// Gets current length of blob
		/// </summary>
		public int Length
		{
			get
			{
				return byteList.Count();
			}
		}

		/// <summary>
		/// Creates new instance of PpkBlobBuilder
		/// </summary>
		public PpkKeyBlobBuilder()
		{
			byteList = new List<byte>();
		}


		~PpkKeyBlobBuilder()
		{
			Clear();
		}
		
		/// <summary>
		/// Adds a string to the blob
		/// </summary>
		/// <param name="str">the string to add</param>
		public void AddString(string str)
		{
			AddBlob(Encoding.UTF8.GetBytes(str));
		}
		
		/// <summary>
		/// Adds 0 pad to byte[] if required and adds the result to the blob
		/// </summary>
		/// <param name="bigInt"></param>
		public void AddBigInt(BigInteger bigint)
		{
            byte[] bytes = bigint.ToByteArray();
            byteList.AddRange(PSUtil.IntToBytes(bytes.Length));
			byteList.AddRange(bytes);
		}

		/// <summary>
		/// Adds byte[] as-is to the blob
		/// </summary>
		/// <param name="blob"></param>
		public void AddBlob(byte[] blob)
		{
			byteList.AddRange(PSUtil.IntToBytes(blob.Length));
			byteList.AddRange(blob);
		}

		/// <summary>
		/// Gets the resulting blob from the blob builder.
		/// </summary>
		/// <returns>byte[] containing the blob</returns>
		public byte[] getBlob()
		{
			return byteList.ToArray();
		}

		/// <summary>
		/// Writes 0 to all values, then clears list
		/// </summary>
		public void Clear()
		{
			PSUtil.ClearByteList(byteList);
		}

			
	}
}
