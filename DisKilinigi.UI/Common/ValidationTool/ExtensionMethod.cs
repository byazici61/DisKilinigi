using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKilinigi.UI.Common
{
	public static class ExtensionMethod
	{

		/// <summary>
		/// //isim soyisim sayı girememez ve boş bırakılamaz. Eğer ad doğru formattaysa "True" değilse "False" döner.
		/// </summary>
		/// <param name="anneKizlikAd"></param>
		/// <param name="kisiAd"></param>
		/// <returns></returns>
		public static bool StringDegerAdSoyadKontrolu(this string txtbox)
		{
			for (int i = 0; i < txtbox.Length; i++)
			{
				if (txtbox.Contains(" ") // Ad en az iki kelimeden oluştuğu için boşluk içermek zorunda ama bu boşluklar başta ve sonda olamaz.
				&& !txtbox.EndsWith(" ")
				&& !txtbox.StartsWith(" ")
				&& (Char.IsLetter(txtbox[i]) || txtbox[i] == ' '))
				{
					return true;
				}
			}
			return false;

		}

		/// <summary>
		/// Girilen string double mı diye kontorl eder. Double "True" değise "False"
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static bool SayiDoubleMi(this string s)
		{
			foreach (char item in s)
			{
				if (!(Char.IsDigit(item) || item == ','))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// parametreler(string) boş bu diye bakar. Değilse "True" döner
		/// </summary>
		/// <param name="texts"></param>
		/// <returns></returns>
		public static bool StringDegerinNullVeyaBoslukOlupOlmamaDurumu(params string[] texts)
		{
			foreach (var item in texts)
			{
				//boş ise girer
				if (item.Any(char.IsWhiteSpace) || string.IsNullOrWhiteSpace(item) || item.Length < 2)
				{
					return false;
				}
			}
			//boş değil
			return true;
		}

		public static bool NullValidasyon(params string[] texts)
		{
			foreach (var item in texts)
			{
				//boş ise girer
				if (string.IsNullOrWhiteSpace(item) || item.Length < 2)
				{
					return false;
				}
			}
			//boş değil
			return true;
		}

		/// <summary>
		/// parametreler(string) rakam içeriyor mu  diye bakar. içermiyorsa "True" döner
		/// </summary>
		/// <param name="texts"></param>
		/// <returns></returns>
		public static bool StringDegerlerdeSayiOlupOlmamaDurumu(params string[] texts)
		{
			foreach (var item in texts)
			{
				//sayi varsa girer
				if (item.Any(char.IsDigit))
				{
					return false;
				}
			}
			//sayi yok
			return true;
		}

		/// <summary>
		/// e-mail kontrolü. Doğru formatta ise True döner
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static bool MailFormatindaOlupOlmamaDurumu(this string email)
		{
			//büyük küçük harfe duyarsız
			return Regex.IsMatch(email,
				@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// tel no 5 ile baslamali. 3-3-4 formatinda olmali. 10 karakter olmali.
		/// </summary>
		/// <param name="telefonNo"></param>
		/// <returns></returns>
		public static bool TelefonNoFormatKontrolu(this string telefonNo)
		{
			return Regex.IsMatch(telefonNo, @"^(5(\d{2})-(\d{3})-(\d{4}))$", RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// tc kimlik no 11 karakter olmali. tek sayi ile bitemez. 0 ile baslayamaz.
		/// </summary>
		/// <param name="tc"></param>
		/// <returns></returns>
		public static bool TCKimlikNoDogruFormattaMi(this string tc)
		{
			return (tc.Length == 11 && tc.Substring(0, 1) != "0" && tc.Substring(10, 1) != "1" && tc.Substring(10, 1) != "1" && tc.Substring(10, 1) != "3" && tc.Substring(10, 1) != "5" && tc.Substring(10, 1) != "7" && tc.Substring(10, 1) != "9")
				? true
				: false;

		}

		//public static void Temizle()

		/// <summary>
		/// formun tüm componentlerini resetler.
		/// </summary>
		/// <param name="form"></param>
		public static void ResetAllControls(Control form)
		{
			foreach (Control control in form.Controls)
			{
				RecursiveResetForm(control);
			}
		}

		private static void RecursiveResetForm(Control control)
		{
			if (control.HasChildren)
			{
				foreach (Control subControl in control.Controls)
				{
					RecursiveResetForm(subControl);
				}
			}
			switch (control.GetType().Name)
			{
				case "TextBox":
					TextBox textBox = (TextBox)control;
					textBox.Text = null;
					break;

				case "ComboBox":
					ComboBox comboBox = (ComboBox)control;
					if (comboBox.Items.Count > 0)
						comboBox.SelectedIndex = 0;
					break;

				case "CheckBox":
					CheckBox checkBox = (CheckBox)control;
					checkBox.Checked = false;
					break;

				case "ListBox":
					ListBox listBox = (ListBox)control;
					listBox.ClearSelected();
					break;

				case "MaskedTextBox":
					MaskedTextBox maskedTextBox = (MaskedTextBox)control;
					maskedTextBox.Clear();
					break;
				case "DateTimePicker":
					DateTimePicker dateTimePicker = (DateTimePicker)control;
					dateTimePicker.Value = DateTime.Now;
					break;
			}
		}
	}
}
