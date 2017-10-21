using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    public class PrimeService
    {
        public bool isPrime( int Candidate)
        {
            if(Candidate < 2)
                return false;
            for(int divisor = 2; divisor <= Math.Sqrt(Candidate); divisor++)
            {
                if(Candidate % divisor == 0)
                return false;
            }
            return true;
        }

        public int[] GetPrimesInRange(int from, int to)
        {   
            List<int> resultList = new List<int>();
            if(from == 1)
              from++;
            for(int i = from;i <= to; i ++)
            {
                if(isPrime(i))
                    resultList.Add(i);
            }               
            return resultList.ToArray();
        }
        
        public async Task<int[]> GetPrimesInRangeAsync(int from, int to)
        {
            return await Task.Run(()=> GetPrimesInRange(from,to));
        }
    }
}