using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Domain
{
    public class Car : PropertyChangedBase
    {
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; NotifyOfPropertyChange(() => Brand); }
        }


        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; NotifyOfPropertyChange(() => Type); }
        }


        private string _chassis;
        public string Chassis
        {
            get { return _chassis; }
            set { _chassis = value; NotifyOfPropertyChange(() => Chassis); }
        }


        private int _noDoors;
        public int NoDoors
        {
            get { return _noDoors; }
            set { _noDoors = value; NotifyOfPropertyChange(() => NoDoors); }
        }


        private int _enginePower;
        public int EnginePower
        {
            get { return _enginePower; }
            set { _enginePower = value; NotifyOfPropertyChange(() => EnginePower); }
        }


        public Car(
            string brand,
            string type,
            string chassis,
            int noDoors,
            int enginePower
        ) {
            _brand = brand;
            _type = type;
            _chassis = chassis;
            _noDoors = noDoors;
            _enginePower = enginePower;
        }
    }
}
