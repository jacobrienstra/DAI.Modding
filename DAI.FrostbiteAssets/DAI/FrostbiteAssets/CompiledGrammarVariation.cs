using System;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompiledGrammarVariation : LinkObject
	{
		[FieldOffset(0, 0)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(4, 4)]
		public CompiledGrammarLocale Locale { get; set; }

		[FieldOffset(8, 8)]
		public uint GrammarId { get; set; }

		[FieldOffset(12, 12)]
		public Guid BinaryChunk { get; set; }

		[FieldOffset(28, 28)]
		public uint BinaryChunkSize { get; set; }
	}
}
