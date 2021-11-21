namespace InterpritAPI.Class
{
    public class Palindrome
    {
        public string? OriginalText { get; set; }

        public bool IsPalindrome { get; set;}

        public string? RemovedText { get; set; }

        public string? PalindromeText { get; set; }

        public override string ToString()
        {
            var template = @"OriginalText: {0}\n
                            IsPalindrome: {1}\n
                            RemovedText: {2}\n
                            PalindromeText: {3}";

            return string.Format(template, string.IsNullOrEmpty(OriginalText)?string.Empty:OriginalText, IsPalindrome,
                                    string.IsNullOrEmpty(RemovedText) ? string.Empty : RemovedText,
                                    string.IsNullOrEmpty(PalindromeText) ? string.Empty : PalindromeText);
        }
    }
}
