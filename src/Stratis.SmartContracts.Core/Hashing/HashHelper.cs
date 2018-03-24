﻿using HashLib;
using Nethereum.RLP;

namespace Stratis.SmartContracts.Core.Hashing
{
    /// <summary>
    /// Utilities to aid with hashing of data.
    /// </summary>
    public static class HashHelper
    {
        public static readonly byte[] EmptyByteArray = new byte[0];
        public static readonly byte[] EmptyDataHash = Keccak256(EmptyByteArray);
        public static readonly byte[] EmptyElementRlp = RLP.EncodeElement(EmptyByteArray);
        public static readonly byte[] EmptyTrieHash = Keccak256(EmptyElementRlp);
        private static readonly IHash Keccak = HashFactory.Crypto.SHA3.CreateKeccak256();

        /// <summary>
        /// Returns a 32-byte Keccak256 hash of the given bytes.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] Keccak256(byte[] input)
        {
            return Keccak.ComputeBytes(input).GetBytes();
        }
    }

    /// <summary>
    /// This gets injected into the contract to provide implementations for the hashing of data. 
    /// </summary>
    public class InternalHashHelper : IInternalHashHelper
    {
        /// <summary>
        /// Returns a 32-byte Keccak256 hash of the given bytes.
        /// </summary>
        /// <param name="toHash"></param>
        /// <returns></returns>
        public byte[] Keccak256(byte[] toHash)
        {
            return HashHelper.Keccak256(toHash);
        }
    }
}