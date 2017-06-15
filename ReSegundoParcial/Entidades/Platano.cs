using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Platano : Fruta
    {
        public string paisOrigen;

        #region Properties

        public string PaisOrigen
        {
            get { return this.paisOrigen; }
            set { this.paisOrigen = value; }
        }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public override ConsoleColor Color
        {
            get { return base._color; }
            set { base._color = value; }
        }

        public override float Peso
        {
            get { return base._peso; }
            set { base._peso = value; }
        }

        public string Tipo
        {
            get { return "Platano"; }
        }

        #endregion

        #region Methods

        public Platano() : base()
        { }

        public Platano(ConsoleColor color, float peso, string paisOrigen)
            : base(color, peso)
        {
            this.paisOrigen = paisOrigen;
        }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tipo: " + this.Tipo);
            sb.AppendLine("Carozo: " + this.TieneCarozo);
            sb.Append(base.FrutaToString());
            sb.AppendLine("Pais de origen: " + this.paisOrigen);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        #endregion

    }
}
