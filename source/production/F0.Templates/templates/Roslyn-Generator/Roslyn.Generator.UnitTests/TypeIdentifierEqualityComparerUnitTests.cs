using Microsoft.CodeAnalysis.CSharp.Syntax;
#if (MSTest)
using Microsoft.VisualStudio.TestTools.UnitTesting;
#elif (NUnit)
using NUnit.Framework;
#else
using Xunit;
#endif
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Roslyn.Generator.UnitTests
{
#if (MSTest)
	[TestClass]
#elif (NUnit)
	[TestFixture]
#endif
	public class TypeIdentifierEqualityComparerUnitTests
	{
#if (MSTest)
		[TestMethod]
#elif (NUnit)
		[Test]
#else
		[Fact]
#endif
		public void Instance_IsSingleton_ReturnsSame()
		{
			var instance = TypeIdentifierEqualityComparer.Instance;

#if (MSTest)
			Assert.AreSame(TypeIdentifierEqualityComparer.Instance, instance);
#elif (NUnit)
			Assert.That(instance, Is.SameAs(TypeIdentifierEqualityComparer.Instance));
#else
			Assert.Same(TypeIdentifierEqualityComparer.Instance, instance);
#endif
		}

#if (MSTest)
		[TestMethod]
		[DataRow("Identifier", "Identifier")]
		[DataRow(null, null)]
#elif (NUnit)
		[Test]
		[TestCase("Identifier", "Identifier")]
		[TestCase(null, null)]
#else
		[Theory]
		[InlineData("Identifier", "Identifier")]
		[InlineData(null, null)]
#endif
		public void Equals_EqualIdentifier_ReturnsTrue(string? left, string? right)
		{
			TypeDeclarationSyntax? x = left is null ? null : ClassDeclaration(left);
			TypeDeclarationSyntax? y = right is null ? null : ClassDeclaration(right);

			bool areEqual = TypeIdentifierEqualityComparer.Instance.Equals(x, y);

#if (MSTest)
			Assert.IsTrue(areEqual);
#elif (NUnit)
			Assert.That(areEqual, Is.True);
#else
			Assert.True(areEqual);
#endif
		}

#if (MSTest)
		[TestMethod]
		[DataRow("Identifier", "identifier")]
		[DataRow(null, "Identifier")]
		[DataRow("Identifier", null)]
#elif (NUnit)
		[Test]
		[TestCase("Identifier", "identifier")]
		[TestCase(null, "Identifier")]
		[TestCase("Identifier", null)]
#else
		[Theory]
		[InlineData("Identifier", "identifier")]
		[InlineData(null, "Identifier")]
		[InlineData("Identifier", null)]
#endif
		public void Equals_UnequalIdentifier_ReturnsFalse(string? left, string? right)
		{
			TypeDeclarationSyntax? x = left is null ? null : ClassDeclaration(left);
			TypeDeclarationSyntax? y = right is null ? null : ClassDeclaration(right);

			bool areEqual = TypeIdentifierEqualityComparer.Instance.Equals(x, y);

#if (MSTest)
			Assert.IsFalse(areEqual);
#elif (NUnit)
			Assert.That(areEqual, Is.False);
#else
			Assert.False(areEqual);
#endif
		}

#if (MSTest)
		[TestMethod]
#elif (NUnit)
		[Test]
#else
		[Fact]
#endif
		public void GetHashCode_NotNull_ReturnsHashCodeOfIdentifier()
		{
			TypeDeclarationSyntax obj = ClassDeclaration("Identifier");

			int hashCode = TypeIdentifierEqualityComparer.Instance.GetHashCode(obj);

#if (MSTest)
			Assert.AreEqual("Identifier".GetHashCode(), hashCode);
#elif (NUnit)
			Assert.That(hashCode, Is.EqualTo("Identifier".GetHashCode()));
#else
			Assert.Equal("Identifier".GetHashCode(), hashCode);
#endif
		}

#if (MSTest)
		[TestMethod]
#elif (NUnit)
		[Test]
#else
		[Fact]
#endif
		public void GetHashCode_Null_ReturnsZero()
		{
			int hashCode = TypeIdentifierEqualityComparer.Instance.GetHashCode(null);

#if (MSTest)
			Assert.AreEqual(0, hashCode);
#elif (NUnit)
			Assert.That(hashCode, Is.Zero);
#else
			Assert.Equal(0, hashCode);
#endif
		}
	}
}
