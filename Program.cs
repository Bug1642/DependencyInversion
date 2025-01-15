using System;
using System.Collections.Generic;

namespace DependencyInversion
{
    public interface IPostable
    {
        void PostContent();
    }

    public class Facebook : IPostable
    {
        public void PostContent()
        {
            Console.WriteLine("Facebook Posted!");
        }
    }
    public class Twitter : IPostable 
    {
        public void PostContent() 
        {
            Console.WriteLine("Twitter Posted!");
        }
    }
    public class Instagram : IPostable
    {
        public void PostContent()
        {
            Console.WriteLine("Instagram Posted!");
        }
    }
    public class SocialMediaService
    {
        List<IPostable> platforms;
        public SocialMediaService(List<IPostable> platforms)
        {
            this.platforms = platforms;
        }
        public void PostToAllPlatforms()
        {
            foreach (var platform in platforms)
            {
                platform.PostContent();
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var platforms = new List<IPostable>
            {
                new Facebook(),
                new Twitter(),
                new Instagram()
            };
            var service = new SocialMediaService(platforms);
            service.PostToAllPlatforms();
        }
    }
}