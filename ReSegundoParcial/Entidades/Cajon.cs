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
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Platano))]
    public class Cajon<T> : ISerializable
    {
        private int _capacidad;
        private List<T> _frutas;
        private float _precioUnitario;
        private string _rutaArchivo;

        #region Properties

        public List<T> Frutas
        {
            get { return this._frutas; }
            set { this._frutas = value; }
        }

        public float PrecioTotal
        {
            get { return this._precioUnitario * this._capacidad; }
        }

        public string RutaArchivo
        {
            get { return this._rutaArchivo; }
            set { this._rutaArchivo = value; }
        }

        public int Capacidad
        {
            get { return this._capacidad; }
            set { this._capacidad = value; }
        }

        public float PrecioUnitario
        {
            get { return this._precioUnitario; }
            set { this._precioUnitario = value; }
        }

        #endregion

        #region Methods

        public Cajon()
        { 
            this._frutas = new List<T>();
        }

        public Cajon(int capacidad)
            :this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(int capacidad, float precioUnitario)
            :this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }

        public static Cajon<T> operator +(Cajon<T> c, T f)
        {
            if (c._frutas.Count < c._capacidad)
            {
                c._frutas.Add(f);
                return c;
            }
            throw new CajonLlenoException("Cajon de " + f.GetType().Name + "s lleno!");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Capacidad: " + this._capacidad.ToString());
            sb.AppendLine("Precio Total: " + this.PrecioTotal);
            foreach (T t in this._frutas)
            {
                sb.AppendLine(t.ToString());
            }

            return sb.ToString();
        }

        public bool SerializarXml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Cajon<T>));
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
                XmlSerializer serializer = new XmlSerializer(typeof(Cajon<T>));
                XmlTextReader reader = new XmlTextReader(this.RutaArchivo);
                Cajon<T> c;

                c = (Cajon<T>)serializer.Deserialize(new FileStream(this.RutaArchivo, FileMode.Open));
                this._capacidad = c._capacidad;
                this._frutas = c._frutas;
                this._precioUnitario = c._precioUnitario;
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
