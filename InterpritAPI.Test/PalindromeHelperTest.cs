using InterpritAPI.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InterpritAPI.Test
{
    [TestClass]
    public class PalindromeHelperTest
    {
        PalindromeHelper helper;
        public PalindromeHelperTest()
        {
            helper = new PalindromeHelper();
        }

        [TestMethod]
        public void Call_GetRemovedText_When_Empty_Text_PassIn_Should_Return_OriginalText()
        {
            var text = string.Empty;

            Assert.AreEqual(helper.GetRemovedText(text,1,1), text);
        }

        [TestMethod]
        public void Call_GetRemovedText_When_Index_Bigger_Than_Text_Length_Should_ThrowException()
        {
            Assert.ThrowsException<Exception> (() => helper.GetRemovedText("txt", 2, 2));
        }

        [TestMethod]
        public void Call_GetRemovedText_When_Proper_Text_PassIn_Should_Return_RemovedText()
        {
            var text = "asdfssdewg";

            var removedText = helper.GetRemovedText(text, 5, 2);

            Assert.AreEqual("asdfsewg", removedText);
        }

        [TestMethod]
        public void Call_GetReverseText_When_SingleCharString_PassIn_Should_Return_OriginalText()
        {
            var originalText = "s";

            Assert.AreEqual(originalText, helper.GetReverseText(originalText));
        }

        [TestMethod]
        public void Call_GetReverseText_When_ProperText_PassIn_Should_ReturnReverseText()
        {
            var originalText = "abcdef";

            var expectedText = "fedcba";

            Assert.AreEqual(expectedText, helper.GetReverseText(originalText));
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_EmptyString_PassIn_Should_ThrowException()
        {
            Assert.ThrowsException<Exception>(() => helper.CheckPossiblePalindrome(string.Empty,2));
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_PalindromeText_PassIn_Should_Return_PalindromeTrueObject()
        {
            var originalText = "asa";

            var result = helper.CheckPossiblePalindrome(originalText, 1);

            Assert.IsTrue(result.IsPalindrome);
            Assert.AreEqual(originalText, result.PalindromeText);
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_InvalidPalindromeText_PassIn_Should_Return_PalindromeFalseObject()
        {
            var originalText = "abc";

            var result = helper.CheckPossiblePalindrome(originalText, 1);

            Assert.IsTrue(!result.IsPalindrome);
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_NoPalindromeText_PassIn_Should_Return_PalindromeFalseObject()
        {
            var originalText = "asaadfafa";

            var result = helper.CheckPossiblePalindrome(originalText, 1);

            Assert.IsTrue(!result.IsPalindrome);
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_PotientalPalindromeText_PassIn_Should_Return_PalindromeTrueObject()
        {
            var originalText = "abchecba";
            var palindromeText = "abcecba";
            var removedText = "h";

            var result = helper.CheckPossiblePalindrome(originalText, 1);

            Assert.IsTrue(result.IsPalindrome);
            Assert.AreEqual(palindromeText, result.PalindromeText);
            Assert.AreEqual(removedText, result.RemovedText);
        }

        [TestMethod]
        public void Call_CheckPossiblePalindrome_When_PotientalPalindromeText_WithIndex2_PassIn_Should_Return_PalindromeTrueObject()
        {
            var originalText = "abchescba";
            var palindromeText = "abcscba";
            var removedText = "he";

            var result = helper.CheckPossiblePalindrome(originalText, 2);

            Assert.IsTrue(result.IsPalindrome);
            Assert.AreEqual(palindromeText, result.PalindromeText);
            Assert.AreEqual(removedText, result.RemovedText);
        }
    }
}