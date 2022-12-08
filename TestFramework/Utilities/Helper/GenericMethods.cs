namespace TestFramework.Utilities.Helper
{
    public static class GenericMethods
    {
        /// <summary>
        /// convert string price to int and remove '₹'
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static int ConvertPriceStringToInt(string price)
        {
            string[] a = price.Split(',');
            return int.Parse(string.Concat(a).Replace("₹", ""));
        }
    }
}
