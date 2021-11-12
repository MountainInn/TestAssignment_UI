using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

public class MarketDataGenerator : MonoBehaviour
{
    public static string pagesPath;


    List<string> avatarPicturesLinks = new List<string>()
    {
        "https://i.pinimg.com/236x/1e/ea/13/1eea135a4738f2a0c06813788620e055.jpg",
        "https://i.pinimg.com/236x/94/f0/ad/94f0ad69d05ed0f21c036003744251b9.jpg",
        "https://i.pinimg.com/236x/7e/67/eb/7e67eb044ae737a98b8779c6332dc179.jpg",
        "https://i.pinimg.com/236x/68/1b/e9/681be9bb128786d915290d5013d05d6d.jpg",
        "https://i.pinimg.com/236x/af/9f/1f/af9f1fed99621ae20f9edd2ab6cbb8bd.jpg",
        "https://i.pinimg.com/236x/c3/51/18/c3511874093854d317bc7c3927132b7b.jpg",
        "https://i.pinimg.com/236x/e7/16/b1/e716b1c5cf1bbf35df9f5927ca0a2480.jpg",
        "https://i.pinimg.com/236x/0e/db/d5/0edbd50fe6bc29c44b8c7818b0feff5b.jpg",
        "https://i.pinimg.com/236x/ff/3e/ae/ff3eae09f456abfccd0312e5fbd30969.jpg",
        "https://i.pinimg.com/236x/b9/8e/aa/b98eaab60c68c7e0772bf262a8c8c9bf.jpg",
        "https://i.pinimg.com/236x/9d/8f/32/9d8f328b53f787f915054be191a40b04.jpg",
        "https://i.pinimg.com/236x/66/a3/a4/66a3a4f348db9e30d79864d7ee63aa39.jpg",
        "https://i.pinimg.com/236x/54/5c/56/545c5695b1f1cd3d636308e149a4d0bf.jpg",
        "https://i.pinimg.com/236x/45/11/57/4511573926637709890f4889dbc0959a.jpg",
        "https://i.pinimg.com/236x/03/bd/1f/03bd1f14dd4a0dbbd011669e76049302.jpg",
        "https://i.pinimg.com/236x/1d/fb/90/1dfb903315e32e4fd84f6768d3be1002.jpg",
        "https://i.pinimg.com/236x/67/02/6e/67026ec8647c10b0114b8ce9f5b579f9.jpg",
        "https://i.pinimg.com/236x/74/a6/45/74a6450314023cf8da27275241ee8ad8.jpg",
        "https://i.pinimg.com/236x/fc/bc/fc/fcbcfc2f09846f583dde8fb5a61b876b.jpg",
        "https://i.pinimg.com/236x/8b/4a/00/8b4a000e38e3d81b53ff9ff46147eb7b.jpg",
        "https://i.pinimg.com/236x/be/37/98/be37983974c3415c08e9522ca12b2139.jpg",
        "https://i.pinimg.com/236x/99/c0/fd/99c0fde56bc10fa65f793e07ed5a840b.jpg",
        "https://i.pinimg.com/236x/3c/7f/05/3c7f05ef933322c4d85edb173258ea1e.jpg",
        "https://i.pinimg.com/236x/e9/db/fc/e9dbfcf6da6a67f0b47776e0cba3a872.jpg",
        "https://i.pinimg.com/236x/fb/9c/ce/fb9cce1b9bfa6fd9f145236ff2bf6628.jpg",
        "https://i.pinimg.com/236x/af/f8/70/aff8705871d8947cefc5685280e1910c.jpg",
        "https://i.pinimg.com/236x/21/f8/c0/21f8c0c28f3580c0a63a44d8f3fc87a5.jpg",
        "https://i.pinimg.com/236x/94/e2/ed/94e2ed9a36c0110e60ddfd8a7942947b.jpg",
        "https://i.pinimg.com/236x/13/e0/12/13e0122f7d49be56d8d7dee810d36a9e.jpg",
        "https://i.pinimg.com/236x/77/50/e5/7750e5a903c7d1e42a44b6ccda20058e.jpg",
        "https://i.pinimg.com/736x/47/1d/86/471d86653fa9bf4703d97e2980df46fe.jpg",
        "https://i.pinimg.com/736x/e6/a3/cc/e6a3cccfbb5af266d17ebfb32f8a69ba.jpg",
        "https://i.pinimg.com/736x/13/62/ab/1362ab7c1094f24527bb3bb326f86551.jpg",
        "https://i.pinimg.com/236x/fe/eb/ab/feebabc90edf2a7a6ef08dedf7223e8e.jpg",
        "https://i.pinimg.com/236x/51/99/23/519923747c857f69f987fce88b76b4d1.jpg",
        "https://i.pinimg.com/236x/ac/07/09/ac07096b4d26a8e96fdad3d6eaa555ab.jpg",
        "https://i.pinimg.com/236x/84/b6/21/84b6215c1545cfa8bef71bf94fbcc317.jpg",
        "https://i.pinimg.com/140x140_RS/dd/94/9d/dd949d7de362a580f04e782adb73a829.jpg",
        "https://i.pinimg.com/236x/7c/63/7f/7c637f4242dbcba68e2440401911b7c1.jpg",
        "https://i.pinimg.com/236x/aa/ac/67/aaac67f268e3396e14eb6fd46efa461c.jpg",
        "https://i.pinimg.com/236x/bc/68/a2/bc68a2a45cd7743d75a0f15e58a46b1b.jpg",
        "https://i.pinimg.com/236x/4a/0f/34/4a0f3470432577f6c519e1c9aca2c741.jpg",
        "https://i.pinimg.com/236x/d0/b0/c0/d0b0c073add18fde4692801b806458cd.jpg",
        "https://i.pinimg.com/236x/91/b0/51/91b0515eb132e0c7d8de73dde8e2aa86.jpg",
        "https://i.pinimg.com/236x/ad/8a/33/ad8a335a252f1b77b015b1fe02e9cf6c.jpg",
        "https://i.pinimg.com/236x/e7/8d/78/e78d786c5cdd33646a5c2dae7658c5a6.jpg",
        "https://i.pinimg.com/236x/b1/07/a5/b107a533269d1172285c51413be74f0f.jpg",
        "https://i.pinimg.com/736x/e2/97/fa/e297fa3459a630697af936d614dd78ee.jpg",
        "https://i.pinimg.com/736x/0a/6a/80/0a6a802bb5f3ce6176bc257db4133de2.jpg",
        "https://i.pinimg.com/736x/b5/42/ff/b542ff43e4f585586d4015fa0f556314.jpg",
        "https://i.pinimg.com/736x/13/3e/9c/133e9cffea9c8bc1b25ee44fa1c8e961.jpg",
        "https://i.pinimg.com/736x/26/e2/93/26e29396a7dad132f19178dd3e534a1a.jpg",
        "https://i.pinimg.com/236x/4f/e6/21/4fe621101ab8dcf8e0bf7baf49aa4d7f.jpg",
        "https://i.pinimg.com/236x/f4/7c/b5/f47cb501dfb6c8a4a918426fafc52721.jpg",
        "https://i.pinimg.com/236x/3a/f6/ce/3af6ce1794513bb2f615dfb6d0f7de3f.jpg",
        "https://i.pinimg.com/236x/92/60/6f/92606f75105383b80461bdfc0d0e57c5.jpg",
        "https://i.pinimg.com/236x/2e/9f/45/2e9f4540c3e7882362478520f8d8b614.jpg",
        "https://i.pinimg.com/236x/a9/e8/3e/a9e83e4af3ff4831f974acf56ab67100.jpg",
        "https://i.pinimg.com/236x/62/d9/87/62d987962ca5f41722b309f0c35e9e03.jpg",
        "https://i.pinimg.com/236x/69/98/0c/69980c72a6f8fd2ce0fe83bcb8380fd6.jpg",
        "https://i.pinimg.com/236x/6e/93/a7/6e93a7f1733f6ed5b99fae92fc17f883.jpg",
        "https://i.pinimg.com/236x/41/04/dd/4104dd83a709f3a161a9d0cc817afead.jpg",
        "https://i.pinimg.com/236x/d7/52/5f/d7525fc1ec75424387946ac8cb01d51e.jpg",
        "https://i.pinimg.com/236x/90/46/33/9046333001c55b1be93412966d358c05.jpg",
        "https://i.pinimg.com/736x/90/15/23/901523c5e397cbee0e0d1674f02602d2.jpg",
        "https://i.pinimg.com/736x/7f/43/01/7f43019b7ebd57bd91b7e0b9bcd899cd.jpg",
        "https://i.pinimg.com/736x/55/4d/ec/554dec89b2ec215016a14b86279e719c.jpg",
        "https://i.pinimg.com/736x/ae/67/21/ae6721f1753d6bc028c5e8aae302a878.jpg",
        "https://i.pinimg.com/236x/00/6a/e3/006ae325af585984d76935dd2b06b55d.jpg",
        "https://i.pinimg.com/236x/f2/ab/10/f2ab10d73f0c4831ca2601d95ab27121.jpg",
        "https://i.pinimg.com/236x/ce/41/01/ce410150b433a8a41749ec777bd90052.jpg",
        "https://i.pinimg.com/236x/98/73/d0/9873d0d0673322a1e19ffd22f91fc45a.jpg",
        "https://i.pinimg.com/736x/4a/ef/aa/4aefaa478bd33fc4de4a68cc0601b4e5.jpg",
        "https://i.pinimg.com/736x/56/35/f9/5635f99ba3e88aed3573774237cc0abf.jpg",
        "https://i.pinimg.com/736x/f1/02/c9/f102c91ea5db997ce9bfb90772cc7f1d.jpg",
        "https://i.pinimg.com/736x/06/dd/a4/06dda410418df0768bee76316bf2a3b4.jpg",
        "https://i.pinimg.com/236x/48/9d/0b/489d0b633938145267dcd064f70b14d2.jpg",
        "https://i.pinimg.com/236x/da/0e/75/da0e75451e2ecd520ba1ca44220ec6cf.jpg",
        "https://i.pinimg.com/236x/ad/f2/2f/adf22f69812a65801e7c10c6b09f0af0.jpg",
        "https://i.pinimg.com/236x/ee/c4/cc/eec4cc9ab8e6431d3efbc719c7b90dd5.jpg",
        "https://i.pinimg.com/236x/51/84/49/5184494afe74cbebf37ecb3c55419924.jpg",
        "https://i.pinimg.com/736x/e6/a3/cc/e6a3cccfbb5af266d17ebfb32f8a69ba.jpg",
        "https://i.pinimg.com/736x/13/62/ab/1362ab7c1094f24527bb3bb326f86551.jpg",
        "https://i.pinimg.com/736x/2a/f7/f2/2af7f2e95ef90f5de51da6eb009127ad.jpg",
        "https://i.pinimg.com/736x/73/a7/b2/73a7b27d00f65bbb1e94c9552ef7907a.jpg",
        "https://i.pinimg.com/236x/0e/89/21/0e89216e295e1c1a897744d22f406f45.jpg",
        "https://i.pinimg.com/236x/25/8b/da/258bda8242c55a84922f8c1bd168d7e8.jpg",
        "https://i.pinimg.com/236x/4f/ee/74/4fee7418990717f8991a80ebefdb1081.jpg",
        "https://i.pinimg.com/236x/41/ff/2c/41ff2c044f7e1a444f9f56117e060228.jpg",
        "https://i.pinimg.com/736x/8b/af/f8/8baff895344fd6e985fa3d74051f5cb0.jpg",
        "https://i.pinimg.com/736x/11/a3/a9/11a3a929c8e7aabcc43dc347ba02dfa6.jpg",
        "https://i.pinimg.com/736x/a6/b2/61/a6b261872f31a43682669c7c266084ce.jpg",
        "https://i.pinimg.com/236x/3b/8e/3f/3b8e3f36831fd9197145c94cb23b3821.jpg",
        "https://i.pinimg.com/236x/54/2c/62/542c628e81db73c54d644886cd786dfe.jpg",
        "https://i.pinimg.com/236x/51/85/d6/5185d66908e9c955be11f146bdf35905.jpg",
        "https://i.pinimg.com/236x/e1/a6/60/e1a660ddd26bb8c3ac8d241a74e581e1.jpg",
        "https://i.pinimg.com/236x/62/8b/c1/628bc1c2d50d8d4f8594645a2fe0a743.jpg",
        "https://i.pinimg.com/236x/0d/21/7d/0d217dfa68dc126f429b5c65955bb72e.jpg",
        "https://i.pinimg.com/236x/b6/b3/22/b6b322923b010a4a5853fb2e3e58466e.jpg",
        "https://i.pinimg.com/236x/26/6f/af/266fafdfb07cc111a95db35c6d263b59.jpg"
    };

    List<string> nicknames = new List<string>()
    {
        "Genius",
        "Rapunzel",
        "Cheerio",
        "Frogger",
        "Buffalo",
        "Grumpy",
        "Skinny Jeans",
        "Cheddar",
        "Amor",
        "Guy",
        "Baby",
        "Dumbledore",
        "Bunny",
        "Fatty",
        "Chef",
        "Thumper",
        "C-Dawg",
        "Azkaban",
        "Blondie",
        "Cutie",
        "Headlights",
        "Fun Dip",
        "Double Double",
        "Butter",
        "Chica",
        "Smudge",
        "Coke Zero",
        "Frau Frau",
        "Cookie Dough",
        "Beauty",
        "Braniac",
        "Snow White",
        "Boomhauer",
        "Biffle",
        "Kitten",
        "Dilly Dally",
        "Golden Grah",
        "French Fry",
        "Tiny",
        "Dragonfly",
        "Sport",
        "Lion",
        "Bumpkin",
        "Chubs",
        "Pecan",
        "Peppa Pig",
        "Bello",
        "Button",
        "Lady",
        "Snake",
        "Twiggy",
        "Munchkin",
        "Doll",
        "Drake",
        "Fattykins",
        "Teeny",
        "Jackrabbit",
        "MomBod",
        "Sunny",
        "Goonie",
        "Prego",
        "Princess",
        "Cheeto",
        "Daria",
        "Bub",
        "Lover",
        "T-Dawg",
        "Chump",
        "Maestro",
        "Lil Girl",
        "Cumulus",
        "Sweety",
        "Shuttershy",
        "Red",
        "Twinkly",
        "Kit-Kat",
        "Belch",
        "Guapo",
        "Fox",
        "Big Mac",
        "Silly Gilly",
        "Ticklebutt",
        "Rufio",
        "Dots",
        "Colonel",
        "Mini Skirt",
        "Junior",
        "Kirby",
        "Goose",
        "Cold Front",
        "Buttercup",
        "Joker",
        "Matey",
        "Captain",
        "Chico",
        "Pookie",
        "Filly Fally",
        "Bubble Butt",
        "Mini Me",
        "Twinkie",
        "Lovey"
    };

    List<(string, string)> itemNames = new List<(string, string)>()
    {
        ("wheat", "Пшеница"),
        ("mushrooms", "Грибы"),
        ("corn", "Кукуруза"),
        ("butter", "Масло")
    };


    void Awake()
    {
        pagesPath = Application.persistentDataPath + "/pages.json";

        if (!File.Exists(pagesPath))
        {
            GenerateJsonFile();
        }
    }

    void GenerateJsonFile()
    {
        var pages = GeneratePages();

        string json = JsonConvert.SerializeObject(pages, Formatting.Indented);

        File.Delete(pagesPath);
        File.WriteAllText(pagesPath, json);
    }

    List<PageData> GeneratePages()
    {
        int
            itemCount = 100,
            fullPages = itemCount / 6,
            lastPageItems = itemCount % 6;


        List<PageData> pages = new List<PageData>();

        for (int i = 0; i < fullPages; i++)
        {
            PageData pageData = new PageData();

            pageData.leftButtonInteractable = (i > 0);
            pageData.rightButtonInteractable = true;
            pageData.closeButtonInteractable = false;
            pageData.items = GenerateItems(6);

            pages.Add(pageData);
        }


        PageData lastPageData = new PageData();

        lastPageData.leftButtonInteractable = true;
        lastPageData.rightButtonInteractable = false;
        lastPageData.closeButtonInteractable = true;
        lastPageData.items = GenerateItems(lastPageItems);

        pages.Add(lastPageData);

        return pages;
    }

    private List<ItemData> GenerateItems(int count)
    {
        List<ItemData> items = new List<ItemData>();

        for (int j = 0; j < count; j++)
        {
            ItemData itemData = new ItemData();
            itemData.avatarLink = avatarPicturesLinks.ExtractRandom();
            itemData.playerName = nicknames.ExtractRandom();
            itemData.price = Random.Range(30, 151);
            itemData.quantity = Random.Range(5, 71);

            (itemData.addressableID, itemData.name) = itemNames.GetRandom();

            items.Add(itemData);
        }

        return items;
    }


}
