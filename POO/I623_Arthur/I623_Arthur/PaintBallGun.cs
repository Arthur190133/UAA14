using System;
using System.Collections.Generic;
using System.Text;

namespace I623_Arthur
{
    class PaintBallGun
    {
        private int _bulletPocket = 0;
        private int _bulletMag = 0;
        private int _magSize = 16;

        public int BulletPocket
        {
            get
            {
                return _bulletPocket;
            }
            set
            {
                _bulletPocket = value;
            }
        }

        public int BulletMag
        {
            get
            {
                return _bulletMag;
            }
            set
            {
                _bulletMag = value;
            }
        }


        public int MagSize
        {
            get
            {
                return _magSize;
            }
        }

        public PaintBallGun(int Pocket, int Mag)
        {
            _bulletPocket = Pocket;
            _bulletMag = Mag;
        }

        public bool IsEmpty() {return (_bulletMag <= 0);}

        public bool Fire()
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                _bulletMag--;
                return true;
            }
        }

        public bool Reload()
        {
            if(_bulletMag == _magSize || _bulletPocket <= 0)
            {
                return false;
            }
            else
            {
                int oldBulletMag = _bulletMag;
                _bulletMag = (_bulletPocket >= _magSize) ? _magSize : _bulletPocket + _bulletMag;
                _bulletPocket -= (_bulletMag - oldBulletMag);
                return true;
            }
        }

        public void TakeBullets()
        {
            _bulletPocket += 30;
        }

        // Question 3
        private void ChangeMagSize(int newMagSize)
        {
            _magSize = newMagSize;
        }
    }
}
