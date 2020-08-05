using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthFunctionTest
    {
        [Test]
        public void FullHealing()
        {
            int testMaxHealth = 3;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);

            healthFunction.FullHeal();
            Assert.AreEqual(testMaxHealth, healthFunction.current);
            
        }
        
        [Test]
        public void Healing()
        {
            int testMaxHealth = 3;
            int startHealth = 1;
            int healingAmount = 1;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);
            healthFunction.current = startHealth;
            
            healthFunction.Healing(healingAmount);
            
            Assert.AreEqual((startHealth + healingAmount), healthFunction.current);
        }
        
        [Test]
        public void OverHealing()
        {
            int testMaxHealth = 3;
            int startHealth = 1;
            int healingAmount = 5;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);
            healthFunction.current = startHealth;
            
            healthFunction.Healing(healingAmount);
            
            Assert.AreEqual(testMaxHealth, healthFunction.current);
        }
        
        [Test]
        public void HealingWhenFull()
        {
            int testMaxHealth = 3;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);

            healthFunction.FullHeal();
            bool canheal = healthFunction.Healing(1);
            
            Assert.AreEqual(testMaxHealth, healthFunction.current);
            Assert.AreEqual(false, canheal);
        }
        
        [Test]
        public void MinusHealing()
        {
            int testMaxHealth = 3;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);

            healthFunction.FullHeal();
            bool canheal = healthFunction.Healing(-1);
            
            Assert.AreEqual(testMaxHealth, healthFunction.current);
            Assert.AreEqual(false, canheal);
        }
        
        [Test]
        public void DamageHealth()
        {
            int testMaxHealth = 3;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);

            healthFunction.FullHeal();
            healthFunction.TakingDamage(1);
            
            Assert.AreEqual(testMaxHealth - 1, healthFunction.current);
        }
        
        [Test]
        public void MinusDamageHealth()
        {
            int testMaxHealth = 3;
            
            HealthFunction healthFunction = new HealthFunction(testMaxHealth);

            healthFunction.FullHeal();
            healthFunction.TakingDamage(-1);
            
            Assert.AreEqual(testMaxHealth, healthFunction.current);
        }
    }
}
