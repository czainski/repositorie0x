    /*
    State
        This pattern gives you a way to manage the generation 
    and management of object properties through another object.
        The example shows how thanks to this pattern can be 
    create and run in a uniform way different cash registers.
    */
    using System;
    using RedirectBC;
    
    class State
    {
        double _balance;
        double _debet { set; get; }
        double _limit { set; get; }
        //     
        public double Balance
        {
            get { return _balance; }
        }//
        public double Debet
        {
            get { return _debet; }
        }//
        public double Deposit(double amount)
        {
            double d = _debet - _limit;
            if (amount > d)
            {
                d =amount- d;
                _debet = _limit;
                _balance += d;
            }
            else
            {
                _debet -= amount;
            }
            return amount;
        }//
        public double Withdraw(double amount)
        {
            double mi = _balance - _debet;
            if (amount > mi)
            {
                _balance=0;
                _debet = 0;
                return mi;
            }
            else
            {    
                if (amount > _balance)
                {
                    double r = amount - _balance; 
                    _debet += r;
                    _balance = 0;
                    return amount;
                }
                else
                {
                    _balance -= amount;
                    return amount;
                }
            }
        }//
        public void Limit(double debet)
        {
            _debet = debet;
            _limit = debet;
        }
    }// 
    class Account
    {
        private State _state;
        //
        public Account()
        {
             _state = new State();
        }//
        public double Balance
        {
            get { return _state.Balance; }
        }//
        public double Debet
        {
            get { return _state.Debet; }
        }//
        public State State
        {
            get { return _state; }
            set { _state = value; }
        }//
        public void Deposit(double amount)
        {
            Report("Deposit", _state.Deposit(amount));
        }//
        public void Withdraw(double amount)
        {
            Report("Withdraw", _state.Withdraw(amount), amount);
        }//
        public void Limit(double limit)
        {
            _state.Limit(limit);
        }//
        public void Report(string headline, params double[] quantity)
        {
            if (quantity.Length == 2)
            {
                Console.WriteLine("\n Request: {2:C} ; {0}: {1:C} ", headline, quantity[0], quantity[1]);
            }
            else 
            {
                Console.WriteLine("\n     {0}: {1:C} ", headline, quantity[0]);
            }
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Debet = {0:C}", Debet);
        }//
    }//
    class Client
    {
        static void Main()
        {
            Redirect.Open();
            
            Console.WriteLine("\n__________ Account I _______________\n");

            Account account1 = new Account();
            account1.Limit(-1000.0);
             
            account1.Deposit(100.0);
            account1.Withdraw(1000.00);

            account1.Deposit(10000.0);
            account1.Withdraw(9500.00);

            Console.WriteLine("\n_________ Account II ______________\n");
            
            Account account2 = new Account();
            account2.Limit(0.0);
            
            account2.Deposit(500.0);
            account2.Withdraw(1000.00);
          
            //Console.ReadKey();
            Redirect.Close();
        }//
    }//
    /*output:
    
    __________ Account I _______________


         Deposit: 100,00 zł 
    Balance = 100,00 zł
    Debet = -1 000,00 zł

    Request: 1 000,00 zł ; Withdraw: 1 000,00 zł 
    Balance = 0,00 zł
    Debet = -100,00 zł

         Deposit: 10 000,00 zł 
    Balance = 9 100,00 zł
    Debet = -1 000,00 zł

     Request: 9 500,00 zł ; Withdraw: 9 500,00 zł 
    Balance = 0,00 zł
    Debet = -600,00 zł

    _________ Account II ______________


         Deposit: 500,00 zł 
    Balance = 500,00 zł
    Debet = 0,00 zł

    Request: 1 000,00 zł ; Withdraw: 500,00 zł 
    Balance = 0,00 zł
    Debet = 0,00 zł

    */