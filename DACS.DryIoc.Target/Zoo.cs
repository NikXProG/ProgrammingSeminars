﻿using System;
using DACS.DryIoc.Domain;

namespace DACS.DryIoc.Target
{
    
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Zoo
    {

        private IAnimal _animal;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        public Zoo(IAnimal animal)
        {
            _animal = animal ?? throw new ArgumentNullException(nameof(animal));
        }

        public void Voice()
        {
            Console.WriteLine(_animal.Voice());
        }
            
    }
    
}