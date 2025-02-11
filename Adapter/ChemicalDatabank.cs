﻿// Adapter pattern -- Real World example

using System;

namespace Adapter.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Adapter Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Non-adapted chemical compound

            var unknown = new Compound("Unknown");

            unknown.Display();


            // Adapted chemical compounds

            Compound water = new RichCompound("Water");

            water.Display();


            Compound benzene = new RichCompound("Benzene");

            benzene.Display();


            Compound ethanol = new RichCompound("Ethanol");

            ethanol.Display();

            Compound gasolina = new RichCompound("Gasolina");

            gasolina.Display();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Alvo' class
    /// </summary>
    internal class Compound
    {
        protected float _boilingPoint;
        protected string _chemical;

        protected float _meltingPoint;

        protected string _molecularFormula;
        protected double _molecularWeight;


        // Constructor

        public Compound(string chemical)
        {
            _chemical = chemical;
        }


        public virtual void Display()
        {
            Console.WriteLine("\nCompound: {0} ------ ", _chemical);
        }
    }


    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    internal class RichCompound : Compound
    {
        private ChemicalDatabank _bank;


        // Constructor

        public RichCompound(string name)
            : base(name)
        {
        }


        public override void Display()
        {
            // The Adaptee

            _bank = new ChemicalDatabank();


            _boilingPoint = _bank.GetCriticalPoint(_chemical, "B");

            _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");

            _molecularWeight = _bank.GetMolecularWeight(_chemical);

            _molecularFormula = _bank.GetMolecularStructure(_chemical);


            base.Display();

            Console.WriteLine(" Formula: {0}", _molecularFormula);

            Console.WriteLine(" Weight : {0}", _molecularWeight);

            Console.WriteLine(" Melting Pt: {0}", _meltingPoint);

            Console.WriteLine(" Boiling Pt: {0}", _boilingPoint);
        }
    }


    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    internal class ChemicalDatabank
    {
        // The databank 'legacy API'

        public float GetCriticalPoint(string compound, string point)
        {
            // Melting Point

            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water":
                        return 0.0f;

                    case "benzene":
                        return 5.5f;

                    case "ethanol":
                        return -114.1f;

                    case "gasolina":
                        return -115.0f;

                    default:
                        return 0f;
                }
            }

            // Boiling Point

            else
            {
                switch (compound.ToLower())
                {
                    case "water":
                        return 100.0f;

                    case "benzene":
                        return 80.1f;

                    case "ethanol":
                        return 78.3f;

                    case "gasolina":
                        return 79.0f;

                    default:
                        return 0f;
                }
            }
        }


        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return "H20";

                case "benzene":
                    return "C6H6";

                case "ethanol":
                    return "C2H5OH";

                case "gasolina":
                    return "C8H8";

                default:
                    return "";
            }
        }


        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return 18.015;

                case "benzene":
                    return 78.1134;

                case "ethanol":
                    return 46.0688;

                case "gasolina":
                    return 18.000;

                default:
                    return 0d;
            }
        }
    }
}