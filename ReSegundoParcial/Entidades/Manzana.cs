using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Manzana : Fruta, ISerializable
    {
        public string distribuidora;
        private string _rutaArchivo;

        #region Properties

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public override ConsoleColor Color
        {
            get{ return base._color; }
            set{ base._color = value; }
        }

        public override float Peso
        {
            get { return base._peso; }
            set { base._peso = value; }
        }

        public string Tipo
        {
            get { return "Manzana"; }            
        }

        public string RutaArchivo
        {
            get { return this._rutaArchivo; }
            set { this._rutaArchivo = value; }
        }

        #endregion

        #region Methods

        public Manzana()
            : base()
        { }

        public Manzana(ConsoleColor color, float peso, string distribuidora)
            : base(color, peso)
        {
            this.distribuidora = distribuidora;
        }

        protected override string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tipo: " + this.Tipo);
            sb.AppendLine("Carozo: " + this.TieneCarozo);
            sb.Append(base.FrutaToString());
            sb.AppendLine("Distribuidora: " + this.distribuidora);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }        

        public bool SerializarXml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                XmlTextWriter writer = new XmlTextWriter(this.RutaArchivo, Encoding.UTF8);

                serializer.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeSerializarXml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
                XmlTextReader reader = new XmlTextReader(this.RutaArchivo);
                Manzana m;

                m = (Manzana)serializer.Deserialize(new FileStream(this.RutaArchivo, FileMode.Open));
                this._color = m._color;
                this._peso = m._peso;
                this.distribuidora = m.distribuidora;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


    }
}
