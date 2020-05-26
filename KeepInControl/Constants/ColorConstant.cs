using Xamarin.Forms;

namespace KeepInControl.Constants
{
    public class ColorConstant
    {
        public static Color Primary { get; private set; }
        public static Color PrimaryDark { get; private set; }

        public static void Init()
        {
            if (Application.Current.Resources.TryGetValue(nameof(Primary), out var primary))
                Primary = Color.FromHex(primary.ToString());

            if (Application.Current.Resources.TryGetValue(nameof(PrimaryDark), out var primaryDark))
                PrimaryDark = Color.FromHex(primaryDark.ToString());
        }
    }
}