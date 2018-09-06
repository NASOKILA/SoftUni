namespace FindMyPet.Web.Static
{
    public static class ValidationConstants
    {
        public const string TypeRequired = "Type is required.";
        public const string TypeAtleastThreeSymbols = "Type must be atleast 3 symbols.";

        public const string NameRequired = "Name is required.";
        public const string NameAtleastThreeSymbols = "Name must be atleast 3 symbols.";
        
        public const string AgeRequired = "Age is required.";
        public const string AgeRangeBetweenZeroAndOnehundred = "Age must be in range between 0 and 100.";

        public const string ImageUrlRequired = "Image Url is required.";

        public const string LocationRequired = "Location is required.";
        public const string LocationAtleastThreeSymbols = "Location must be atleast 3 symbols.";

        public const string TimeLostRequired = "Time Lost is required.";
    }
}
