﻿namespace InfinityCinema.Data.Common
{
    using System;

    public class DataValidation
    {
        public class MovieValidation
        {
            public const int NameMaxLength = 200;
            public const int DescriptionMaxLength = 1000;
            public const int TrailerPathMaxLength = 2048;
            public const int ImageUrlMaxLength = 2048;
        }

        public class ActorValidation
        {
            public const int FirstNameMaxLength = 60;
            public const int LastNameMaxLength = 60;
        }

        public class CommentValidation
        {
            public const int ContentMaxLength = 600;
        }

        public class GenreValidation
        {
            public const int NameMaxLength = 60;
            public const int ImageUrlMaxLength = 2048;
        }

        public class LanguageValidation
        {
            public const int NameMaxLength = 150;
            public const int AbbreviationMaxLength = 10;
        }

        public class PlatformValidation
        {
            public const int NameMaxLength = 60;
            public const int PathUrlMaxLength = 2048;
            public const int IconUrlMaxLength = 2048;
        }

        public class ApplicationUserValidation
        {
            public const int FirstNameMaxLength = 60;
            public const int LastNameMaxLength = 60;
        }
    }
}