using System;

namespace Exercise4
{
    class Movie
    {
        private string _title;
        private string _studio;
        private string _rating;

        public Movie(string title, string studio, string rating)
        {
            this.Title = title;
            this.Studio = studio;
            this.Rating = rating;
        }

        public Movie(string Title, string Studio)
        {
            this.Title = Title;
            this.Studio = Studio;
            Rating = "PG";
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Studio
        {
            get => _studio;
            set => _studio = value;
        }

        public string Rating
        {
            get => _rating;
            set => _rating = value;
        }

        public static Movie[] GetPG(Movie[] array)
        {
            int index = default;
            int newArrayLength = default;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Rating.ToLower() == "pg")
                {
                    newArrayLength++;
                }
            }

            Movie[] newArray = new Movie[newArrayLength];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Rating.ToLower() == "pg")
                {
                    newArray[index] = array[i];
                    index++;
                }
            }

            return newArray;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Movie first = new Movie("Casino Royale", "Eon Productions","PG13");
            Movie second = new Movie("Glass", "Buena Vista International","PG13");
            Movie third = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures","PG");
            Movie[] movies = { first, second, third };
            Movie[] filteredMovies = Movie.GetPG(movies);
            foreach(var movie in filteredMovies)
            {
                Console.WriteLine($"{movie.Title} || {movie.Studio} || {movie.Rating}");
            }
        }
    }
}
