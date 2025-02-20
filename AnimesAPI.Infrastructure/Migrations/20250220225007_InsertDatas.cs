using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimesAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Animes", // Nome da tabela onde os dados serão inseridos
            columns: new[] { "Name", "Director", "Description", "IsDeleted" }, // Colunas a serem inseridas
            values: new object[,]
            {
                { "Naruto", "Masashi Kishimoto", "Naruto é um anime de ação e aventura que segue a jornada de Naruto Uzumaki, um ninja jovem que sonha em se tornar o líder de sua vila.", false },
                { "One Piece", "Eiichiro Oda", "One Piece segue a jornada de Monkey D. Luffy, um jovem pirata, enquanto ele busca o lendário tesouro One Piece.", false },
                { "Attack on Titan", "Hajime Isayama", "A história de Attack on Titan ocorre em um mundo onde os humanos vivem atrás de enormes muralhas para se proteger de gigantes devoradores de pessoas.", false },
                { "Demon Slayer", "Koyoharu Gotouge", "Demon Slayer segue a jornada de Tanjiro Kamado, que se torna um caçador de demônios após sua família ser massacrada.", false },
                { "Dragon Ball Z", "Akira Toriyama", "Dragon Ball Z segue as aventuras de Goku e seus amigos enquanto defendem a Terra de poderosos vilões.", false },
                { "My Hero Academia", "Kohei Horikoshi", "Em um mundo onde quase todos têm superpoderes, Izuku Midoriya, um jovem sem poderes, sonha em se tornar um herói.", false },
                { "Fullmetal Alchemist: Brotherhood", "Yasuhiro Irie", "Fullmetal Alchemist: Brotherhood segue os irmãos Edward e Alphonse Elric enquanto buscam a Pedra Filosofal para restaurar seus corpos.", false },
                { "Tokyo Ghoul", "Sui Ishida", "Tokyo Ghoul segue a vida de Ken Kaneki, um jovem que se torna meio ghoul após um acidente, forçado a viver entre os humanos e ghouls.", false },
                { "Hunter x Hunter", "Yoshihiro Togashi", "Hunter x Hunter segue Gon Freecss, um jovem que busca encontrar seu pai e se tornar um Hunter, uma classe de elite de exploradores.", false },
                { "One Punch Man", "Yusuke Murata", "One Punch Man segue Saitama, um herói extremamente poderoso que pode derrotar qualquer inimigo com um único soco.", false },
                { "Death Note", "Tsugumi Ohba", "Death Note segue um estudante chamado Light Yagami que encontra um caderno que lhe permite matar qualquer pessoa cujo nome ele escreva nele.", false },
                { "Bleach", "Tite Kubo", "Bleach segue Ichigo Kurosaki, um jovem com a habilidade de ver espíritos, que se torna um Ceifador de Almas.", false },
                { "Sword Art Online", "Rei Kawahara", "Sword Art Online segue Kirito, que fica preso em um jogo de realidade virtual e deve lutar pela sua vida.", false },
                { "Fairy Tail", "Hiro Mashima", "Fairy Tail segue Natsu Dragneel e seus amigos enquanto enfrentam aventuras e batalhas no mundo da magia.", false },
                { "Neon Genesis Evangelion", "Hideaki Anno", "Neon Genesis Evangelion segue Shinji Ikari, um jovem que se torna piloto de uma poderosa máquina de combate chamada Eva.", false },
                { "Cowboy Bebop", "Shinichirō Watanabe", "Cowboy Bebop segue um grupo de caçadores de recompensas espaciais enquanto viajam pelo universo, caçando criminosos.", false },
                { "Pokémon", "Satoshi Tajiri", "Pokémon segue Ash Ketchum, um jovem treinador de Pokémon, enquanto viaja pelo mundo para capturar e treinar Pokémon.", false },
                { "Inuyasha", "Rumiko Takahashi", "Inuyasha segue Kagome Higurashi e Inuyasha, um meio-demônio, enquanto viajam entre o Japão feudal e o mundo moderno.", false },
                { "Yu Yu Hakusho", "Yoshihiro Togashi", "Yu Yu Hakusho segue Yusuke Urameshi, um adolescente rebelde que se torna um detetive do mundo espiritual após sua morte.", false },
                { "Gintama", "Hideaki Sorachi", "Gintama segue Gintoki Sakata, um samurai vagabundo em um mundo alternativo onde alienígenas dominaram o Japão feudal.", false }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
