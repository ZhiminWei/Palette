using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Palette.Extension;
using Palette.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Palette.ViewModels
{
    internal class ChineseTraditionalColorsViewModel : ObservableObject
    {


        public ChineseTraditionalColorsViewModel()
        {
            TraditionColorList1 = new ObservableCollection<Tradition1>()
            {
                new Tradition1()
                {
                    ColorTypeName = "白色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#F3F2F2",ColorName ="精白", Content="精白出世心，太虚惜可誓。"},
                        new TraditionColor{ Hex="#EAECD4",ColorName ="象牙", Content="独把象牙梳插鬓，昆仑山上月初明。"},
                        new TraditionColor{ Hex="#EDEAE6",ColorName ="鱼肚", Content="西塞山前白鹭飞，桃花流水鱖鱼肥。"},
                        new TraditionColor{ Hex="#EFE8DA",ColorName ="缟", Content="恸哭六军俱缟素，冲冠一怒为红颜。"},
                        new TraditionColor{ Hex="#EFEBD5",ColorName ="乳", Content="矮纸斜行闲作草，晴窗细乳戏分茶。"},
                        new TraditionColor{ Hex="#F3EAE0",ColorName ="荷花", Content="绿杨堤畔问荷花，记得年时沽酒，那人家？"},
                        new TraditionColor{ Hex="#E8EAED",ColorName ="浅云", Content="云鬓鬅松眉黛浅。"},
                        new TraditionColor{ Hex="#EAE7B4",ColorName ="古", Content="尔曹身与名俱灭，不废江河万古流。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "天青",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#C0CED5",ColorName ="天青", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#A0BFC4",ColorName ="景天", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#82AAB4",ColorName ="西子", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#72A8AF",ColorName ="正清", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#4A8E99",ColorName ="天水", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#458287",ColorName ="扁青", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#627E90",ColorName ="太师", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#539C8A",ColorName ="五庄", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "绿色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#9DC7B2",ColorName ="玉簪", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#5CB787",ColorName ="蔻梢", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#70A498",ColorName ="梧枝", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#47AF52",ColorName ="玉髓", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#36957A",ColorName ="青姬", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#2F8C58",ColorName ="宫离", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#246C49",ColorName ="荷青", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#1DB561",ColorName ="翡兹", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "蓝色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#B4C3D0",ColorName ="云水", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#8BB8CB",ColorName ="秋波", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#91AEC4",ColorName ="晴山", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#238BBC",ColorName ="甸子", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#1988AE",ColorName ="鸢尾", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#2A73AC",ColorName ="景泰", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#4D779A",ColorName ="蝶翅", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#5796B3",ColorName ="天韵", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "红色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#F13A57",ColorName ="海棠", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#EB3738",ColorName ="枸杞", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#E84F34",ColorName ="杨妃", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#E91C0C",ColorName ="绯红", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#C13C5A",ColorName ="狱吠", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#C33141",ColorName ="高粱", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#95242D",ColorName ="朱樱", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#965565",ColorName ="桑脂", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "黄色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#F2DB43",ColorName ="明黄", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#F1CA23",ColorName ="佛收", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#E9BA1B",ColorName ="素馨", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#EFAF10",ColorName ="琥珀", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#F3A01D",ColorName ="金柔", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#E4D32B",ColorName ="柘黄", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#D3A31D",ColorName ="玳瑁", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#D2B360",ColorName ="文狮", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },new Tradition1()
                {
                    ColorTypeName = "橙色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#E77345",ColorName ="谷鞘", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#EA8637",ColorName ="瑜玉", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#DE5C1D",ColorName ="芙蓉", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#D13B0E",ColorName ="瓜瓤", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#DE5822",ColorName ="凌霄", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#D15726",ColorName ="章丹", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#BF522F",ColorName ="蟹鳌", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#943917",ColorName ="朱柿", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },new Tradition1()
                {
                    ColorTypeName = "粉色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#E2ACBA",ColorName ="彤管", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#E294AA",ColorName ="渥赭", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#E37C9B",ColorName ="子姜", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#DE507C",ColorName ="莲瓣", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#E4787F",ColorName ="香叶", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#DB7586",ColorName ="山藜", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#E199A1",ColorName ="合欢", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#E3698A",ColorName ="春饮", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "黑色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#625756",ColorName ="黝黑", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#5D5259",ColorName ="湮墨", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#3F3E44",ColorName ="鹰背", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#160F16",ColorName ="乌黑", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#0D0D19",ColorName ="漆黑", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#1A1A1A",ColorName ="澜夜", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#353631",ColorName ="京元", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#2A2A26",ColorName ="乌鸦", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "棕色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#9E8174",ColorName ="倌", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#8F6D58",ColorName ="画眉", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#8C5643",ColorName ="赭石", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#804913",ColorName ="棕", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#76412F",ColorName ="丁香", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#673225",ColorName ="可可", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#482B27",ColorName ="火山", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#7B361F",ColorName ="鸦鹄", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "灰色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#DCD9D0",ColorName ="珍珠", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#C8C6C1",ColorName ="玛瑙", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#B0B4B7",ColorName ="星灰", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#AAAEAF",ColorName ="月魄", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#A49D94",ColorName ="绍衣", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#8D7B72",ColorName ="邺灰", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#646056",ColorName ="相思", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#858888",ColorName ="白衣", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
                new Tradition1()
                {
                    ColorTypeName = "紫色",
                    TraditionColorList = new List<TraditionColor>
                    {
                        new TraditionColor{ Hex="#9D95BD",ColorName ="雪青", Content="两个黄鹂鸣翠柳，一行白鹭上青天。"},
                        new TraditionColor{ Hex="#BB7FAB",ColorName ="罗兰", Content="欲知窈窕呈祥日，恰近清明淑景天。"},
                        new TraditionColor{ Hex="#BA7297",ColorName ="樱草", Content="西子五湖归去后，泛仙舟，尚许寻盟否。"},
                        new TraditionColor{ Hex="#7C3C83",ColorName ="桔梗", Content="梨花风起正清明，游子寻春半出城。"},
                        new TraditionColor{ Hex="#7F6E99",ColorName ="槿紫", Content="惆怅中何寄，江天水一泓。"},
                        new TraditionColor{ Hex="#7C5D8E",ColorName ="蕈草", Content="草合离宫转夕晖，孤云飘泊复何依？"},
                        new TraditionColor{ Hex="#89286E",ColorName ="青莲", Content="帝赐后村奎画在，作堂安用扁青涂。"},
                        new TraditionColor{ Hex="#785696",ColorName ="渊瑜", Content="慌然身在龙头上，笑引庄生五石樽。"},
                    }
                },
            };



            TraditionColorList2 = new ObservableCollection<Tradition1>()
            {
                 new Tradition1 ()
                 {
                      ColorTypeName = "立春",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#fff799",ColorName ="黄白游"},
                              new TraditionColor{ Hex="#ffee6f",ColorName ="松花"},
                              new TraditionColor{ Hex="#ecd452",ColorName ="缃叶"},
                              new TraditionColor{ Hex="#b6a014",ColorName ="苍黄"},
                              new TraditionColor{ Hex="#d5ebe1",ColorName ="天缥"},
                              new TraditionColor{ Hex="#b1d5c8",ColorName ="沧浪"},
                              new TraditionColor{ Hex="#99bcac",ColorName ="苍筤"},
                              new TraditionColor{ Hex="#80a492",ColorName ="缥碧"},
                              new TraditionColor{ Hex="#8b7042",ColorName ="流黄"},
                              new TraditionColor{ Hex="#775039",ColorName ="栗壳"},
                              new TraditionColor{ Hex="#5f4321",ColorName ="龙战"},
                              new TraditionColor{ Hex="#422517",ColorName ="青骊"},
                              new TraditionColor{ Hex="#f3a694",ColorName ="海天霞"},
                              new TraditionColor{ Hex="#ee7959",ColorName ="缙云"},
                              new TraditionColor{ Hex="#ba5140",ColorName ="纁黄"},
                              new TraditionColor{ Hex="#c12c1f",ColorName ="珊瑚赫"}
                       }
                 },new Tradition1 ()
                 {
                      ColorTypeName = "雨水",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#f9d3e3",ColorName ="盈盈"},
                              new TraditionColor{ Hex="#ecb0c1",ColorName ="水红"},
                              new TraditionColor{ Hex="#dd7694",ColorName ="苏梅"},
                              new TraditionColor{ Hex="#a76283",ColorName ="紫茎屏风"},
                              new TraditionColor{ Hex="#beb1aa",ColorName ="葭灰"},
                              new TraditionColor{ Hex="#b49273",ColorName ="黄埃"},
                              new TraditionColor{ Hex="#a46244",ColorName ="老僧衣"},
                              new TraditionColor{ Hex="#6b5458",ColorName ="玄天"},
                              new TraditionColor{ Hex="#e5a84b",ColorName ="黄河琉璃"},
                              new TraditionColor{ Hex="#e18a3b",ColorName ="库金"},
                              new TraditionColor{ Hex="#984f31",ColorName ="缊韨"},
                              new TraditionColor{ Hex="#7c461e",ColorName ="紫瓯"},
                              new TraditionColor{ Hex="#c0d695",ColorName ="欧碧"},
                              new TraditionColor{ Hex="#a9be7b",ColorName ="春辰"},
                              new TraditionColor{ Hex="#779649",ColorName ="碧山"},
                              new TraditionColor{ Hex="#4f6f46",ColorName ="青青"}
                       }
                 },new Tradition1 ()
                 {
                      ColorTypeName = "惊蛰",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#ba5b49",ColorName ="赤缇"},
                              new TraditionColor{ Hex="#a64036",ColorName ="朱草"},
                              new TraditionColor{ Hex="#9e2a22",ColorName ="綪茷"},
                              new TraditionColor{ Hex="#7c191e",ColorName ="顺圣"},
                              new TraditionColor{ Hex="#f6bec8",ColorName ="桃夭"},
                              new TraditionColor{ Hex="#f091a0",ColorName ="杨妃"},
                              new TraditionColor{ Hex="#dc6b82",ColorName ="长春"},
                              new TraditionColor{ Hex="#c35c5d",ColorName ="牙绯"},
                              new TraditionColor{ Hex="#fedc5e",ColorName ="黄栗留"},
                              new TraditionColor{ Hex="#fac03d",ColorName ="栀子"},
                              new TraditionColor{ Hex="#db9b34",ColorName ="黄不老"},
                              new TraditionColor{ Hex="#c67915",ColorName ="柘黄"},
                              new TraditionColor{ Hex="#9aa7b1",ColorName ="青鸾"},
                              new TraditionColor{ Hex="#6b798e",ColorName ="菘蓝"},
                              new TraditionColor{ Hex="#45465e",ColorName ="青黛"},
                              new TraditionColor{ Hex="#2c2f3b",ColorName ="绀蝶"}
                       }
                 },new Tradition1 ()
                 {
                      ColorTypeName = "春分",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#ebeee8",ColorName ="皦玉"},
                              new TraditionColor{ Hex="#ebeddf",ColorName ="吉量"},
                              new TraditionColor{ Hex="#e0e0d0",ColorName ="韶粉"},
                              new TraditionColor{ Hex="#c7c6b6",ColorName ="霜地"},
                              new TraditionColor{ Hex="#d2af9d",ColorName ="夏籥"},
                              new TraditionColor{ Hex="#bc836b",ColorName ="紫磨金"},
                              new TraditionColor{ Hex="#b26d5d",ColorName ="檀色"},
                              new TraditionColor{ Hex="#9a6655",ColorName ="赭罗"},
                              new TraditionColor{ Hex="#ea5514",ColorName ="黄丹"},
                              new TraditionColor{ Hex="#d23918",ColorName ="洛神珠"},
                              new TraditionColor{ Hex="#c8161d",ColorName ="丹雘"},
                              new TraditionColor{ Hex="#a72126",ColorName ="水华朱"},
                              new TraditionColor{ Hex="#3271ae",ColorName ="青冥"},
                              new TraditionColor{ Hex="#007175",ColorName ="青雘"},
                              new TraditionColor{ Hex="#284852",ColorName ="青緺"},
                              new TraditionColor{ Hex="#12264f",ColorName ="骐驎"}
                       }
                 },new Tradition1 ()
                 {
                      ColorTypeName = "清明",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#a6559d",ColorName ="紫蒲"},
                              new TraditionColor{ Hex="#8a1874",ColorName ="赪紫"},
                              new TraditionColor{ Hex="#6c216d",ColorName ="齐紫"},
                              new TraditionColor{ Hex="#422256",ColorName ="凝夜紫"},
                              new TraditionColor{ Hex="#bec2b3",ColorName ="冻缥"},
                              new TraditionColor{ Hex="#9d9d82",ColorName ="春碧"},
                              new TraditionColor{ Hex="#919177",ColorName ="执大象"},
                              new TraditionColor{ Hex="#79836c",ColorName ="苔古"},
                              new TraditionColor{ Hex="#d3ccd6",ColorName ="香炉紫烟"},
                              new TraditionColor{ Hex="#9b8ea9",ColorName ="紫菂"},
                              new TraditionColor{ Hex="#7e527f",ColorName ="拂紫绵"},
                              new TraditionColor{ Hex="#663d74",ColorName ="三公子"},
                              new TraditionColor{ Hex="#cb5c83",ColorName ="琅玕紫"},
                              new TraditionColor{ Hex="#b83570",ColorName ="红踯躅"},
                              new TraditionColor{ Hex="#a73766",ColorName ="魏红"},
                              new TraditionColor{ Hex="#903754",ColorName ="魏紫"}
                       }
                 },
                new Tradition1 ()
                 {
                      ColorTypeName = "清明",
                       TraditionColorList = new List<TraditionColor> 
                       {
                              new TraditionColor{ Hex="#a6559d",ColorName ="紫蒲"},
                              new TraditionColor{ Hex="#8a1874",ColorName ="赪紫"},
                              new TraditionColor{ Hex="#6c216d",ColorName ="齐紫"},
                              new TraditionColor{ Hex="#422256",ColorName ="凝夜紫"},
                              new TraditionColor{ Hex="#bec2b3",ColorName ="冻缥"},
                              new TraditionColor{ Hex="#9d9d82",ColorName ="春碧"},
                              new TraditionColor{ Hex="#919177",ColorName ="执大象"},
                              new TraditionColor{ Hex="#79836c",ColorName ="苔古"},
                              new TraditionColor{ Hex="#d3ccd6",ColorName ="香炉紫烟"},
                              new TraditionColor{ Hex="#9b8ea9",ColorName ="紫菂"},
                              new TraditionColor{ Hex="#7e527f",ColorName ="拂紫绵"},
                              new TraditionColor{ Hex="#663d74",ColorName ="三公子"},
                              new TraditionColor{ Hex="#cb5c83",ColorName ="琅玕紫"},
                              new TraditionColor{ Hex="#b83570",ColorName ="红踯躅"},
                              new TraditionColor{ Hex="#a73766",ColorName ="魏红"},
                              new TraditionColor{ Hex="#903754",ColorName ="魏紫"}
                       }
                 },
            };













        }



        #region ObservableCollection<TraditionColor> TraditionColorList1 传统色1
        /// <summary>
        /// 传统色1 字段
        /// </summary>
        private ObservableCollection<Tradition1> _TraditionColorList1;
        /// <summary>
        /// 传统色1 属性
        /// </summary>
        public ObservableCollection<Tradition1> TraditionColorList1
        {
            get => _TraditionColorList1;
            set
            {
                if (_TraditionColorList1 != value)
                {
                    _TraditionColorList1 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion



        #region ObservableCollection<Tradition1> TraditionColorList2 节气色
        /// <summary>
        /// 节气色 字段
        /// </summary>
        private ObservableCollection<Tradition1> _TraditionColorList2;
        /// <summary>
        /// 节气色 属性
        /// </summary>
        public ObservableCollection<Tradition1> TraditionColorList2
        {
            get => _TraditionColorList2;
            set
            {
                if (_TraditionColorList2 != value)
                {
                    _TraditionColorList2 = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion







        #region CopyCommand 复制命令
        /// <summary>
        /// 复制命令
        /// </summary>
        public ICommand CopyCommand => new RelayCommand<object>((o) =>
        {
            if (!string.IsNullOrEmpty(o?.ToString()))
            {
                try
                {
                    Clipboard.SetText(o.ToString());
                    MessageExtension.Show($"已复制: {o.ToString()}");
                }
                catch (Exception ex)
                {
                    MessageExtension.Show(ex.Message);
                }
            }
        });
        #endregion


    }

    public class Tradition1
    {
        public Tradition1()
        {
            TraditionColorList = new List<TraditionColor>();
        }
        public string ColorTypeName { get; set; }

        public List<TraditionColor> TraditionColorList { get; set; }
    }
}
