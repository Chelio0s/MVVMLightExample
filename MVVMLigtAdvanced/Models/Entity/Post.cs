/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMLigtAdvanced"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Collections.Generic;

namespace MVVMLigtAdvanced.Models
{
    partial class Post
    {
        public override bool Equals(object obj)
        {
            var post = obj as Post;
            return post != null &&
                   Id == post.Id &&
                   Title == post.Title;
        }

        public override int GetHashCode()
        {
            var hashCode = -1568206167;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }
        public override string ToString()
        {
            return Title;
        }

    }
}
