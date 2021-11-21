using InterpritAPI.Class;
using System.Text;

namespace InterpritAPI.Domain
{
    public class PalindromeHelper
    {
        const int minTextLength = 3;
        public Palindrome CheckPossiblePalindrome(string text, int removeTextLength)
        {
            var palindrome = new Palindrome();

            if (string.IsNullOrEmpty(text)) throw new Exception(string.Format("text cannot be empty or less than {0}", minTextLength));

            text = text.Trim().ToLower();

            palindrome.OriginalText = text;

            var reverseText = GetReverseText(text);

            if(text.Equals(reverseText))
            {
                palindrome.PalindromeText = text;
                palindrome.IsPalindrome = true;

                return palindrome;
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int n = 1; n <= removeTextLength; n++)
                {
                    if (i + n >= text.Length-1) continue;

                    var removedText = GetRemovedText(text, i, n);

                    reverseText = GetReverseText(removedText);

                    if(removedText.Equals(reverseText))
                    {
                        palindrome.PalindromeText = removedText;
                        palindrome.RemovedText = text.Substring(i, n);
                        palindrome.IsPalindrome = true;

                        return palindrome;
                    }
                }                
            }

            return palindrome;
        }

        public string GetReverseText(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length == 1) return text;

            var strChars = text.ToCharArray();
            var reverseStringBuilder = new StringBuilder();

            for (int i = strChars.Length - 1; i >= 0; i--)
            {
                reverseStringBuilder.Append(strChars[i].ToString());
            }

            return reverseStringBuilder.ToString();
        }

        public string GetRemovedText(string text, int index, int length)
        {
            if (string.IsNullOrEmpty(text)) return text;

            if (index + length >= text.Length) throw new Exception(string.Format("Remove index({0} with length {1} cannot bigger than text length({2}",index,length, text.Length));

            var textStringBuilder = new StringBuilder(text);

            return textStringBuilder.Remove(index, length).ToString();
        }
    }
}
