﻿// Bridge pattern -- Real World example

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Bridge Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create RefinedAbstraction

            var customers = new Customers("Chicago");


            // Set ConcreteImplementor

            customers.Data = new CustomersData();


            // Exercise the bridge

            customers.Show();

            customers.Next();

            customers.Show();

            customers.Next();

            customers.Show();

            customers.Last();

            customers.Add("Henry Velasquez");

            customers.Last();

            customers.ShowAll();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    internal class CustomersBase
    {
        private DataObject _dataObject;

        protected string group;


        public CustomersBase(string group)
        {
            this.group = group;
        }


        // Property

        public DataObject Data
        {
            set { _dataObject = value; }

            get { return _dataObject; }
        }


        public virtual void Next()
        {
            _dataObject.NextRecord();
        }


        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }


        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }


        public virtual void Delete(string customer)
        {
            _dataObject.DeleteRecord(customer);
        }


        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }


        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);

            _dataObject.ShowAllRecords();
        }

        public virtual void Last()
        {
            _dataObject.LastRecord();
        }
    }


    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    internal class Customers : CustomersBase
    {
        // Constructor

        public Customers(string group)
            : base(group)
        {
        }


        public override void ShowAll()
        {
            // Add separator lines

            Console.WriteLine();

            Console.WriteLine("------------------------");

            base.ShowAll();

            Console.WriteLine("------------------------");
        }
    }


    /// <summary>
    /// The 'Implementor' abstract class
    /// </summary>
    internal abstract class DataObject
    {
        public abstract void NextRecord();

        public abstract void PriorRecord();

        public abstract void AddRecord(string name);

        public abstract void DeleteRecord(string name);

        public abstract void ShowRecord();

        public abstract void ShowAllRecords();

        public abstract void LastRecord();
    }


    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    internal class CustomersData : DataObject
    {
        private readonly List<string> _customers = new List<string>();

        private int _current;


        public CustomersData()
        {
            // Loaded from a database

            _customers.Add("Jim Jones");

            _customers.Add("Samual Jackson");

            _customers.Add("Allen Good");

            _customers.Add("Ann Stills");

            _customers.Add("Lisa Giolani");
        }


        public override void NextRecord()
        {
            if (_current <= _customers.Count - 1)
            {
                _current++;
            }
        }


        public override void PriorRecord()
        {
            if (_current > 0)
            {
                _current--;
            }
        }


        public override void AddRecord(string customer)
        {
            _customers.Add(customer);
        }


        public override void DeleteRecord(string customer)
        {
            _customers.Remove(customer);
        }


        public override void ShowRecord()
        {
            Console.WriteLine(_customers[_current]);
        }


        public override void ShowAllRecords()
        {
            foreach (string customer in _customers)
            {
                Console.WriteLine(" " + customer);
            }
        }

        public override void LastRecord()
        {
            Console.WriteLine(_customers.Last());
        }
    }
}