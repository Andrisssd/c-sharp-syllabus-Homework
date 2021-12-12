using System;
using System.Collections.Generic;
using System.Text;

namespace AdApp
{
    class Poster: Advert
    {
        private Size _size;
        private int _copyRate;
        private int _numOfCopies;
        private int _fee;

        public Poster(int height, int fee, int numOfCopies) : base(fee)
        {
            _size = new Size(height, height);
            _fee = fee;
            _numOfCopies = numOfCopies;
        }

        public override int Cost()
        {
            _copyRate = (_size.Height * _size.Width) * _fee;
            return _copyRate * _numOfCopies;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    struct Size
    {
        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public int Height;
        public int Width;
    }
}
