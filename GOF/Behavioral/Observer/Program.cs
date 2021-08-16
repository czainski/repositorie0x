    /*
    Observator
        An object of class with an observed property registers all objects
    whose want to observer changing value this  property. 
    When it follows changing the value of observed property all  
    observers are receive messages about it.
    */
    using System;
    using System.Collections.Generic;
    //using RedirectBC;
    //
    abstract class Temperature
    {
        public string _what; //"Temperature water" or "Temperature air"
        private double _temperature;
        private List<Observator> _observators = new List<Observator>();

        public void Register(Observator observator)
        {
            _observators.Add(observator);
        }//
        public double SetUpTemperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    foreach (Observator observator in _observators)
                        observator.InformObservator(this);
                    Console.WriteLine("");
                }
            }
        }//
        public string What
        {
            get { return _what; }
        }//
        public void Detach(Observator observator)
        {
            _observators.Remove(observator);
        }//
    }//
    class WaterTemerature : Temperature
    {
        public WaterTemerature() 
        {
            _what = "Temerature of Water: "; 
        }
    }//
    class AirTemperature : Temperature
    {
        public AirTemperature() 
        {
            _what = "Air Temperature: "; 
        }
    }//
    class Observator
    {
        private string _nameObservator;
        public Observator(string name)
        {
            this._nameObservator = name;
        }//
        public void InformObservator(Temperature temperatura)
        {
            Console.WriteLine("For: {0} ; {1} {2}°", _nameObservator, temperatura.What,
                temperatura.SetUpTemperature);
        }//
    }//
    class Client
    {
        static void Main()
        {
            //Redirect.Open();
            
            Observator observator1 = new Observator("Heathrow Airport");
            Observator observator2 = new Observator("Millennium Hotel");
            Observator observator3 = new Observator("Panama City Beach");
                        
            WaterTemerature waterTemerature  = new WaterTemerature();
            AirTemperature  airTemperature   = new AirTemperature();
                                  
            airTemperature.Register(observator1);
            airTemperature.Register(observator2);
    
            waterTemerature.Register(observator2);
            waterTemerature.Register(observator3);
            
            waterTemerature.SetUpTemperature = 15;
            airTemperature.SetUpTemperature = 25;

            waterTemerature.Detach(observator3);

            waterTemerature.SetUpTemperature = 20;
            airTemperature.SetUpTemperature = 35;
            
            Console.ReadKey();
            //Redirect.Close();
        }
    }//
    /*output:
    For: Millennium Hotel ; Temerature of Water:  15°
    For: Panama City Beach ;  Temerature of Water:  15°

    For: Heathrow Airport ; Air Temperature:  25°
    For: Millennium Hotel ; Air Temperature:  25°

    For: Millennium Hotel ; Temerature of Water:  20°

    For: Heathrow Airport ; Air Temperature:  35°
    For: Millennium Hotel ; Air Temperature:  35°
    */