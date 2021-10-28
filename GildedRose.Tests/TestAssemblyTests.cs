using Xunit;
using GildedRose;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void Run_Main_Method()
        {
            Program.Main(new string[1]);
        }
        
        [Fact]
        public void Test_Brie_Age_One_Day_Quality_Increases_By_One()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(1, app.Items[0].GetQuality());
            Assert.Equal(1, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Brie_Age_One_Day_Past_SellIn_Date_Quality_Increases_By_Two()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new AgedBrie { Name = "Aged Brie", SellIn = -1, Quality = 0 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(2, app.Items[0].GetQuality());
            Assert.Equal(-2, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Brie_Age_One_Day_Quality_Stops_At_50()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 50 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(50, app.Items[0].GetQuality());
            Assert.Equal(1, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Vest_Age_One_Day_Quality_Decreases_By_One()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Normal { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
        
            //Then
            Assert.Equal(19, app.Items[0].GetQuality());
            Assert.Equal(9, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Vest_Age_One_Day_Past_SellIn_Date_Quality_Decreases_By_Two()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Normal { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
        
            //Then
            Assert.Equal(18, app.Items[0].GetQuality());
            Assert.Equal(-2, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Vest_Age_One_Quality_Stops_At_0()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Normal { Name = "+5 Dexterity Vest", SellIn = 2, Quality = 0 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
        
            //Then
            Assert.Equal(0, app.Items[0].GetQuality());
            Assert.Equal(1, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Elixir_Age_One_Day_Decreases_Quality_By_One()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Normal { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(6, app.Items[0].GetQuality());
            Assert.Equal(4, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Sulfuras_Age_One_Day_SellIn_Day_0_Quality_Does_Not_Change()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(80, app.Items[0].GetQuality());
            Assert.Equal(0, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_Sulfuras_Age_One_Day_SellIn_Day_MinusOne_Quality_Does_Not_Change()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(80, app.Items[0].GetQuality());
            Assert.Equal(-1, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_BackstagePass_Age_One_Day_With_Sellin_Date_100_Quality_Increases_By_One()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new BackStagePass { 
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 100,
                    Quality = 20 }
            };
            var app = new Program(){Items = items};

            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(21, app.Items[0].GetQuality());
            Assert.Equal(99, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_BackstagePass_Age_One_Day_With_Sellin_Date_10_Quality_Increases_By_Two()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new BackStagePass { 
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20 }
            };
            var app = new Program(){Items = items};
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(22, app.Items[0].GetQuality());
            Assert.Equal(9, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_BackstagePass_Age_One_Day_With_Sellin_Date_5_Quality_Increases_By_Three()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new BackStagePass { 
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20 }
            };
            var app = new Program(){Items = items};
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(23, app.Items[0].GetQuality());
            Assert.Equal(4, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Test_BackstagePass_Age_One_Day_With_Sellin_Date_0_Quality_Goes_To_Zero()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new BackStagePass { 
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20 }
            };
            var app = new Program(){Items = items};
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(0, app.Items[0].GetQuality());
            Assert.Equal(-1, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Conjured_Items_Aged_One_Day_Quality_Goes_Two_Down_AND_Sellin_Goes_Down_By_One()
        {
            //Arrange
            IList<IItem> items = new List<IItem>{
                new Conjured { 
                    Name = "Conjured Mana Cake",
                    SellIn = 10,
                    Quality = 20 }
            };
            var app = new Program(){Items = items}; 

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(18, app.Items[0].GetQuality());
            Assert.Equal(9, app.Items[0].GetSellIn());
        }

        [Fact]
        public void Conjured_Items_Aged_One_Day_With_Sellin_Date_0_Quality_Goes_With_Four()
        {
            //Given
            IList<IItem> items = new List<IItem>{
                new Conjured { 
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 20 }
            };
            var app = new Program(){Items = items};
            
            //When
            app.UpdateQuality();
            
            //Then
            Assert.Equal(16, app.Items[0].GetQuality());
            Assert.Equal(-1, app.Items[0].GetSellIn());
        }
    }
}