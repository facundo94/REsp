using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        #region Properties

        public abstract bool TieneCarozo
        { get;}

        public abstract ConsoleColor Color
        { get; set; }

        public abstract float Peso
        { get; set; }

        #endregion

        #region Methods

        public Fruta()
        { }

        public Fruta(ConsoleColor color, float peso)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Color: " + this._color.ToString());
            sb.AppendLine("Peso: " + this._peso.ToString());

            return sb.ToString();
        }

        #endregion

    }
}
