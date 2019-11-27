using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameAd
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			AddGames();
			listBoxGames.ItemsSource = Games();
		}

		private static List<Game> Games()
		{
			using (Context context = new Context("Server=BorisHome\\Boris;Database=GameAd;Trusted_Connection=True;"))
			{
				return context.Games.ToList();
			}
		}

		private static void AddGames()
		{
			using (Context context = new Context("Server=BorisHome\\Boris;Database=GameAd;Trusted_Connection=True;"))
			{
				Game game1 = new Game
				{
					MainImage = "https://images-na.ssl-images-amazon.com/images/I/510RHE9vePL.jpg",
					Developer = "CD Projekt Red",
					Name = "The Witcher 3: Wild Hunt",
					Price = 6900,
					ReleaseDate = new DateTime(2015, 5, 18),
					Rating = 9.3,
					Genre = "action/RPG",
					Description = $"«Ведьмак 3: Дикая Охота» — это сюжетная ролевая игра с открытым миром. Её действие разворачивается в поразительной волшебной вселенной, и любое ваше решение может повлечь за собой серьёзные последствия. Вы играете за профессионального охотника на монстров Геральта из Ривии, которому поручено найти Дитя предназначения в огромном мире, полном торговых городов, пиратских островов, опасных горных перевалов и заброшенных пещер." +
					$"\nОСНОВНЫЕ ОСОБЕННОСТИ" +
					$"\nИГРАЙТЕ ЗА ПРОФЕССИОНАЛЬНОГО УБИЙЦУ ЧУДОВИЩ" +
					$"\nВедьмаки с детства готовятся к борьбе с чудовищами.Благодаря мутациям и усердным тренировкам ведьмаки обретают сверхчеловеческие способности," +
					$"\nсилу и скорость реакции.Только они могут дать отпор чудовищам," +
					$"\nкоторые в их мире совсем не редкость." +
					$"\n" +
					$"\nБез пощады уничтожайте врагов," +
					$"\nиграя за профессионального охотника на чудовищ.В вашем распоряжении целый арсенал улучшаемого оружия," +
					$"\nмутагенных зелий и боевых заклинаний." +
					$"\nОхотьтесь на самых разных чудовищ," +
					$"\nот диких высокогорных тварей до хитрых созданий," +
					$"\nчто таятся в тёмных переулках больших городов." +
					$"\nНа заработанные деньги улучшайте оружие," +
					$"\nприобретайте небывалую броню... или просто спускайте всё на скачки," +
					$"\nигры," +
					$"кулачные бои и другие приятные развлечения."
				};
				context.Games.Add(game1);
				context.Pictures.AddRange(
					new Picture { GameId = game1.Id, Value = "https://steamcdn-a.akamaihd.net/steam/apps/292030/ss_107600c1337accc09104f7a8aa7f275f23cad096.1920x1080.jpg" },
					new Picture { GameId = game1.Id, Value = "https://steamcdn-a.akamaihd.net/steam/apps/292030/ss_64eb760f9a2b67f6731a71cce3a8fb684b9af267.1920x1080.jpg" },
					new Picture { GameId = game1.Id, Value = "https://steamcdn-a.akamaihd.net/steam/apps/292030/ss_b74d60ee215337d765e4d20c8ca6710ae2362cc2.1920x1080.jpg" },
					new Picture { GameId = game1.Id, Value = "https://steamcdn-a.akamaihd.net/steam/apps/292030/ss_90a33d7764a2d23306091bfcb52265c3506b4fdb.1920x1080.jpg" }
				);

				Game game2 = new Game
				{
					MainImage = "https://upload.wikimedia.org/wikipedia/en/thumb/4/44/Red_Dead_Redemption_II.jpg/220px-Red_Dead_Redemption_II.jpg",
					Name = "Red Dead Redemption 2",
					Developer = "Rockstar Studios",
					Price = 23192.91,
					ReleaseDate = new DateTime(2019, 11, 5),
					Rating = 9.2,
					Genre = "Action-adventure",
					Description = "America, 1899. The end of the Wild West era has begun. After a robbery goes badly wrong in the western town of Blackwater, Arthur Morgan and the Van der Linde gang are forced to flee. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him."
				};
				context.Games.Add(game2);

				context.Pictures.AddRange(
					new Picture { GameId = game2.Id, Value = "https://pmcvariety.files.wordpress.com/2018/12/Red-Dead-Redemption-2.png" },
					new Picture { GameId = game2.Id, Value = "https://cdn.pocket-lint.com/r/s/970x/assets/images/147087-games-review-red-dead-redemption-2-screens-image13-hdbmt7yoru.jpg" },
					new Picture { GameId = game2.Id, Value = "https://icdn1.digitaltrends.com/image/digitaltrends/red-dead-redemption-2-review-feature-header.jpg" },
					new Picture { GameId = game2.Id, Value = "https://specials-images.forbesimg.com/imageserve/5d0659db142c50000a3312e7/960x0.jpg" }
				);
				context.SaveChanges();
			}
		}

		private void listBoxGameClicked(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item != null)
			{
				using (Context context = new Context("Server=BorisHome\\Boris;Database=GameAd;Trusted_Connection=True;"))
				{
					Game chosenGame = context.Games.Where(g => g.Id == Guid.Parse(item.Content.ToString())).FirstOrDefault<Game>();
					GameWindow gameWindow = new GameWindow();
					gameWindow.Title = chosenGame.Name;
					gameWindow.Icon = new BitmapImage(new Uri(chosenGame.MainImage, UriKind.Absolute));
					gameWindow.name.Text = chosenGame.Name;
					gameWindow.mainImage.Source = new BitmapImage(new Uri(chosenGame.MainImage, UriKind.Absolute));
					gameWindow.developer.Text = "Developer: " + chosenGame.Developer;
					gameWindow.genre.Text = "Genre: " + chosenGame.Genre;
					gameWindow.description.Text = "Description: " + chosenGame.Description;
					gameWindow.price.Text = "Price: " + chosenGame.Price.ToString() + " тенге";
					gameWindow.rating.Text = "Rating: " + chosenGame.Rating.ToString() + "/10";
					gameWindow.releaseDate.Text = "Release Date: " + chosenGame.ReleaseDate.Date.ToString("D");
					gameWindow.imagesOfGame.ItemsSource = context.Pictures.Where(p => p.GameId == chosenGame.Id).ToList();
					gameWindow.ShowDialog();
				}
			}
		}
	}
}
