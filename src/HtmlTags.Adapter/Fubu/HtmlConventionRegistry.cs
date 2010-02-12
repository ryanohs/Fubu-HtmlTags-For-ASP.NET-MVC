using System;
using System.Collections.Generic;
using FubuMVC.Core.Util;
using FubuMVC.UI.Tags;

namespace FubuMVC.UI
{
    public class HtmlConventions : TagProfileExpression
    {
        private readonly Cache<string, TagProfile> _profiles =
            new Cache<string, TagProfile>(name => new TagProfile(name));


        public HtmlConventions()
            : base(new TagProfile(TagProfile.DEFAULT))
        {
            _profiles[TagProfile.DEFAULT] = profile;
        }

        public IEnumerable<TagProfile> Profiles { get { return _profiles.GetAll(); } }

        public void Profile(string profileName, Action<TagProfileExpression> configure)
        {
            var expression = new TagProfileExpression(_profiles[profileName]);
            configure(expression);
        }
    }
}