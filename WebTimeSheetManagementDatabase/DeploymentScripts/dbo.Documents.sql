CREATE PROCEDURE [dbo].[Populate_dbo_Documents]
AS
BEGIN
/*
	Table's data:    [dbo].[Documents]
	Data Source:     [DESKTOP-S4VLAOQ].[TimesheetDB]
	Created on:      4/29/2021 2:21:55 PM
	Scripted by:     DESKTOP-S4VLAOQ\Alacer02
	Generated by:    Data Script Writer - ver. 2.3.0.0
	GitHub repo URL: https://github.com/SQLPlayer/DataScriptWriter/
*/
PRINT 'Populating data into [dbo].[Documents]';

IF OBJECT_ID('tempdb.dbo.#dbo_Documents') IS NOT NULL DROP TABLE #dbo_Documents;
SELECT [DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType] INTO #dbo_Documents FROM [dbo].[Documents] WHERE 0=1;

SET IDENTITY_INSERT #dbo_Documents ON;

INSERT INTO #dbo_Documents 
 ([DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType])
SELECT CAST([DocumentID] AS int) AS [DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType] FROM 
(VALUES
	  (1,	'download.png',	0x89504E470D0A1A0A0000000D49484452000000C9000000FB0803000000F7AA4091000000E1504C5445FFFFFF000000F4F4F591919BAEAEB5FCFCFC5A5A6BD6D6DA0F0F37D9D9DCF1F1F2E4E4E6AAAAB1898994E8E8EA9A9AA3B7B7BD00002883838F47475C000008797986CCCCD0C4C4C9A3A3ABDEDEE1D0D0D49898A1B4B4BA6F6F7D0000324141573A3A5217173B00001F62627200002352526500002E00002A27274471717F656575E08A953C3C5400001D7D7D89F1CFD32F2F4A0000141F1F3FEAB4BA1B1B3D000018D86676E397A0CD1138F9EBEDF3D7DAC80008E49BA4DB7380DE818DE9B0B7D75F6FF7E4E6D23E55D44B5FCE2442CA0025EAB3B9D0304BC90018CB002FEEC5C95E9A05AA00001B4449444154789CED5D0B9B9B36B31E2E02232EC6601060637B6D631BC7EBD89B4DD3A44DDA7CED69BF93FFFF83CE8C005F9234C93ABB9B7D4E799F275A8225462F9290461A8D005AB4F8D160888FEE1C7E687E66D54DF651FCFA9EBC515DB3E69A9DA4AFD2343F7E46E03DA150E68A777A83F7E41F535122007FDFDB27C90020D0017281F78D69AF89AFC87F5C99EFC0BE01880B53E9BDDC821E000C92AED2DBFB00E5753F83F0BAD753D8688E0130A537BF7A102630E6D0E3A74C6EAABF568E4422BA4A12000D9994C8244C8F312B2618AA1DDE37AC7D69960062EB6B005DA73B0488441E03CCEC42525F34D11F0A130FAED4CF30C9D698AD40E52A249AAA0698B100B355C6FC405BC11FFB30C5243B1EF2D09B993355F5BB35930413659100558530A344234F5547B050398787C19798403CBAD2C059AE563DBFFEB9BC1A99F5656F75B3EAC154E5D68E8FBD3C9D59D3D5950B43C92419F5E6311563A4D8C6D5CD82C36AA58C30D5F266772AEE1EB1F1A0836FC96B1ACB191384AE3975ED6AB0B2ABBF55EDEAEF76AB31DF60CB9AD5B5CB9565E23BC3AA691987DAB5E1C784F70FBE8BBD025F52BF793CEF78B6ED01F30D1554BC7274A70BE0D64CE8B7D9598BBFC676B2E213C9C4F0BC612234CFEBFA0307E980E67B5E6817C2B353E8A97063436ADB69F1204CCA22DCD157B118D737D4F178BC29219D842EC4BBF1C48121B24844F56BB019EF9A7A8EE500630891FC9AE3E72175D3F17882ACC56EE28383D57120409B8CC75E808FDCB102C5DCC06A3C0E1F84488B162D5AB468D1A2458BFB839A34E33F8495249699206C101872F03164E0E838F4836EE2A0A29D24FE3F3FEC14F418C0146A33E4F79204B5B11445DC3B0902EF220E54CCA24807B36E77600BBCAD719F4206491FF5A304AF1D197E1315871E0C7D94502BE61EDDC8520A1F840AC737661D55027C8D9ACCE82CA370552B1B7BA8148E44ED00D89B6F79B0D4681869BFABEA468CCA991FA4582CDDEEBD65FF1CDE203E5C23132C132D05D11D6858B906038DF4937E9335D219BD6F52211C4CFA192678613E4C9950EE4E6A3E31C9756C26201C6780541C87A81C99F406DAF6DBB4BA041F009F32B1DC0722C2BBC7DA95096C0675ED2284727661CE8FB54B638BA13EF866FD54A15740159250D7AE64987E39D1A5509320D0B2EADAEE06DD14B4C275B7E9307003077F74039D81D6DF020C83C0F5D511469B7CCB833176E0838E7FEAEF0947498374B8D3DC20FE72D24BA90CFDC3836D1DDF57EAFBFED0CB86FE5005819758B930C45F87BE0F0CB3A58A2F3CEE00BF497488CD8743133CBAFF40A5D2A2458B7F0358681846C4312CB4B4C0508F2914430ACD2E855E80514258CB90A2E73291EBD18F8949A12F288C1D0A530DC3508D647483201345EA518653C9F0A58C44CA70293ACB0F32D65246206574A58C6125433FCAF0CEA99888945168AB147A9C42EE51A8DA14B29442B0644881F5ED89CC43F810327E4CE1B768D1E24960DE09C1BBBA1A95908D76230DFCABABC5619D6D3BEAD13A5BE17DE1015FC4E26A01707555CBC8F14EE6D27D3FA17040BA4330EAE160D2E8CC8F6B8BB7F88FCD3B06FEB1AE502F8B978B2EE88BABAB2B915C5D2D4D2831C5EC3C53EC86A976C1274C8D4BF073361CF82E63DD9A4A2954364BC1502E5D8B1DA9B4987B8D3242292307937403F0FB52F77571A0BC2519F6CC5459B3C608FB258E996F996A21954C59832899EA7481AB100C5D5D65A555F6BDB5F2119379B5C22C352D81645C7F70D4B15546CBEBA1BDBBB44CAA754694A18EF8187585C25C8B482EB10EE8E72DBEB1594C2BA613947073582D259D0E4BC85B5579208B099D8AB29B4080FAC13A5B9BB3746C9F33E961821DEFF716C85F3211FBC5343946282C60F09D4CFAD3FD0ABC4A061013061513D9B7E5FD693F85703FEDD74C98D4B3E90D1F1F5411C117ACEDAF1501337CBDE1474CE69209BE7880A64C92B3590FA47239935EBFDF5F5299A094B12D575C8534AAA89834A834ECC5A10E1313A6482266BFACA868D21003826AD207137C5C2664897185256F22952C421DDBD78E1338465C49995CBAD05F95C95432D98045AF2BDECA8C9D143B1452F11E1D1BE3FE384146EDC42F65A17C990952513A906285CC8A4C51942D38588E5AF3C6668A62C104EF5FD8E60F762B202D70CCD0A467053E85CDEB9A2944647794403FBE64144EEA3B42513057034A110D1BEEAB567D6ED1E25F0C9550854C06A7E1C98FFF14DE31D1BDCA3803BBEE7446059F773A8BC8A470207A9DCE72982C3B9D5E162C3A9DB9371B753A53B6EB743AD740D1276C8AE1CCA6E86E4CD1139DA20B8DA25B25853C1C51F40E41260AA58CD23ACAD0A58CD8A5E876256332AA657476950C8FA20799943194320614DD8C64C67E4CD9B768D1A2458B162D5AB468D1E289207186BAE33895558B97E8F83F9AE3499D6ACA26733C103AC540241F2D9F71199DAC256CA7B2BF319D8FE6AC1E11EEA0DFEB6ADA40272E9E56F6C703CA5AA2E46423025B258699B21D6804F76326DAB63F91D3F34365AD131757F946D3BD07419F360471A532EFCAFA720D019CF95CA1F9FDA01F43DEFF47652EADA746FDE95CA10945ADFF4DD62F0F04C9C4EB574651713F907F9D97B9930CD28AC9B54BC68183CFCCC05A0D93FD1AA35B3078824CFA3A644992147B62A2911D67F7338BCC0726FD84EC461363FFC3997C52BBFA0E8681D2BBFE4AED9213F5F542D040994F7F1C9340EBF734D7D586F213E4E6FD8D56B578AAF6995FC8161F610C44F051A9786ED4DF69558BA72974CB9FFDC016AF0F7D7F381C5619E0F43F5D7E856BBB3373E8414C1108FAC7DF2E199D2CE2EC61F515B686ED4CCFBF07E961F9DA8FA2BCB183D5AA2A1005B408BD2ECB80B9645F5CFD6896DBD287B82CF30C8626DC0BD66574FC8F9DD056E9F26E0DCA1E6F0F976B37D6EA8C6DAA2145461FFF5C081193C96C5A6FD3E4EE2C4E8453C6626006F7D37E0D9471C88817E6606A427CAB21BF84E5760F0F2083E1A8FE44360B7A9FB7E1F603D007B4EFD71DBAF7C344C071DFAFB74D72A816BEEFF0049E8A63A9BAC3CF32C98C590E7CBA9E158DE5333271BAFA6E6D38EC9ECA0461D435DB0B3CEB0226CD0AB3C43F30812C8B4BD6B14CFF9CC9D63407D93D9509840D11B0F6EBF02AB984C979EDAA33363ED9EB40E833AC5D7653BB847BAC5DF7D36317B6EC9C7811806A5A7AC12513F70E4F30C7BB5158AF93EB8B55A8D763C0F1A608372A18CA0660128685C717D8E227D58FD96D271CA849A7081316DC14E1F8FB2DFF15A3080DAC598A14111BA0EAE350BBCB32BA9A22EAF7CFF1B219CC7A786D31486DCCA485D7C0F09D31FB9888D7D1294CBFDFDB003D85245479513D29E4A1FC31B47834648766E5AC56AB4EA6AD5623AC45C6A4C3A1C03BD83E16AB9BF1971E711F58AC26CDA53DBA0D2046D157C917127C02F365D05C6A09B90AC97DAEAEB15DACB085F43C8E773A2A7F3017220D462AF726D565BA56B970F1DBC53E5EEAFD22E2FCD89F547B8272B3B22522ABA8CAEFCD037A753940A98CB508D2C2A98C95ABC59DF6A7317664D29D2E51338DE6B75369E8431671CB2589E8F76EEF35DB9F815219D04964FBE57C0BAACAF4C117D37C8C933271C8662FCF0C697A454C966AEDFD487D682AA74C80413CA3BF77ECE3E3431F5FB981C96328A8BF254BB5C3B31FBC86554661C0AB590FD390BE8FEED4C7C7D28AACBA766986016638FCD89864AAC6A147BF9215D9F4BE73FE0914E525D47DBCA95089F8D252AD458BA7013F6FAEA89D9422A2B6618727069D7839074EB7431B835CD6614583AEA2E8FFF0D0BBA36A2712A6A2AC2F68274239F4F15DC577952CAA34F9139F6AF45DE933B989976CC58F9D69728F44E0F07D943DE3FACEFA495C66C7FE04C7086E1C09468384134F640A307E839A16F62D56014C6CE3401A8BC3C0B92F22A7FD496AA08C883A07E752ED57F307228883F9626F9D3359601FCFFB8B5E819AE902BB5F102FA724E4619840BA5FF422885F2EE617F7F15859A2B8AE5DE453ED5026D06C11A7DA5541972ED2BE23EFE768C65DBC92591B7DDF65E0C5F8306F869C35139F738FB19DA98ECF98D08858ADB6A1331C22A316CFDCCFAD325C867A2C2C7B46269578C69D3B8D20B3CE6E725B17224D9469A49FAC3ADE7AB21B35D994632E156FDFE4B65C0B119DD56D22F599FB9B76AFF413BEC22FA3B5A01211771B0AB778EAE0A945BB72685205EC34B580C6C40FE5C4E21CF5DC8A04B3688645B52E9F5BE15A18EA2A0FC2B1605E1E161BD8B3C7D118E57C57517F179918870157F5F06EF35DA720E78E5D734D3B69EA5D5AF4857F2426DEA14868EF4D358EB8531F7F8A83A60585ED8A0CFF2EE2CC7A1C268661CCEA7A4C5FFA187B833BEB8C47544CCA24333716B83343C0ED6C9D3F0E1342B5E7ECBE98586A54E4F94896F49C2DE1B16A17CD935F631B89CD8A49F95D4CFC440837CD33AC5D692604D6D4E9A3B5F8592CD7B4A88FF75C21743DBDEB9AD619FC32B7802C84BA7C504639832D32C9BF9EEE3E9047D4B1AB1176EC5E5E3A17AC33B668D1A2458B162D5AB4F801F08F666783685B02596447B0DD4601A8E5D6C5E19D57463A9851104402441465A749101F9B70DF0587F9692903615E3E14365DD198D0758742F8702D47F50A5EBAE0EBB722A311B7A37311CC841D77851858A75651012CA0BC944BDE4CA67A01C9C0C1F0E652F504D2C12474EA4980CA6F6A8F352E21680D70428E6249C746D22E3986C532F04FADA2B2ED627DE97B9C8986898A0A52360353732F66828A81D6ACE55BDBB5C11A26E59A3CE9D06CA755796881A15B9FE472C604D2CEA536526B134ED632D3C0B3342E2E67E2EF8EF64D669C95B0AC989831E9A21F337176EBF54A9C310916C6A74FFD26E0DBEA9587FFA9BA23167978F164ADEE945D373BFE7FCE2AAFA975ED2226B276ADEB32D99A66E99F5AAA9571272B2E6B275996CDF12D72C3053BA0DAC532532B2FB591F6D4C0F7EA76B22D8A3086D428428B66D50CAA5D3700CC2F8A009F4FC71775AB76B29371244C247FB9D12DBD30D2E3D55AC6E5D35DF4A0C3A45F6A599427195A080069AB06CCB44808C780AC723CEEE18FE6C15226FD8EAFB09461D952863489E3ADD9FAFF2324ABF1E62606777763438E255B3CD0614A9FC5D5EE600C67DFEC640B117732543B85CA23C70357787CEDD10CF7FC112D2A6FB967D75452837B02A9C4F3CBFB13A0CE41CE705B6CCCC2C7F4CB7462A9C6B8ECE34570F1642AD44CB2CA307CF3A8DB0ECFECBB20CB9108F8DFC9249A2F16FB9496501ED347E93913E42194D1627AF99AA92C13C1A0B0C9586DF5882DBE19A54E0D39578FB58B7D57CFB81D56966A637B87756BFA9836D4CA9E8AA4B65453E4B4BA1E7C31458B163F049AA228E40D937C0FEE521AD5D76E04C9548D56EAD20959AA290FB436745C3C93269DE23B2C3AC986BB14EB8C56B1C919E615AC88462542557672278DF5506B5CCAE1185352821A7F9097A1B62592ABD80532B9C172502A4D8B01EF87924973D2E47D439EE8286185E491F482DD4D47745F4EB176C9FEC4825051508F873931995F8F80AFD8EE01992887C10AA4FDF93EA7DA357F79374BB523AA1D02D17CB9C43EBEB2E13ECCADD02E40AE180FC664B95C2C69C3B7AACAB9824C5AA30F2FEDE36B1B897ADC2547C31513C6B9CA6FC15B148D8C874063C39DCE982AB6C054E7D22281EA40A30099E469E5F399865E0BB8BDBDBD9A30AC591EB230A3AF3DE652907922BFC522B7971DECDDC5BCB554FB7F056EA72A7864ACC6800EB0055251E8B01ADB0666DB76B35D50C56B2EE756B0FDD0FD7B1834938C1AACDA97A85E3E8055B5CD4687358D852DBE1E4F3220C36105ECC9B8F054251C8FEB36127746638D75E984EFA17B1B8E27DFBFB31C6534A74F3031196F39B0C1E54361B2541B98A5EC19C9DBF792611F5F7F850BB63A8959ED96EDCA79E1FBD92D2B2DDEABCB742BE720F59BCB55C6DABECBB1D2B14D2FE8166E8CAC6262DA6A27350F8ABDDCC15C33E99E4CDC5D8E739D511D2659222E57B42A26D1D8982DBDC237AD112CC14889090B47EC7A661C8AFB8489B69915F7E0B6E09C8915F06A65E3421093542DA967B48D62B6BEA6B97AA52F4B7E7456BB68A7BF64E2DE67ED9A92A59A05AA59F5BFDFC1C44FE2D8B52A3B48DA55DE61D8C7470AACE3588CD8328BE3FAE5737786852FBA713C305D0D7FFD7E35996444551F6F4771AC276AACADE38BA777FCF5DA023A4471C0C923460011F6F1D8E9CEF2DC6539A26E83661ED1DA9558A30630C4DBEB7B98199BE5B47CA2E6F841F4D67902E6BA8C2E5E206BD1A2458B162D5AB46871BF6051A0055DB54BBE4CC1DE6E7D3AEF174426703C3F34E97CDBA85644B500AFC9B39A0B2A5E1EA66DACED56402C1381BFDDE290D509B6AA8C8FD1B72E6A7D38245707A06E83661F6A16B8DBF34372936A08EDBAA45447010AD1AA63886D4A936E83ED573586A1BE14820C6A32C3D37C3F11FE2486813370C0EFF2A1E3FBC37A98DE23AF83B0F57D5F53E7C26F8E2CB206BEDF15D2BE6B2812FCD17374DF77D5818C0E8266FC9501F01BE6FABE5327F2A235EA01A7D918574368B1C73411CA10CD99C29951C9F0BFBE6F8F5D915B388CBECEA4D99950BAD0D5BB983F5E9FF05D3391A1D4E748D3F2EAC3AE7C7CE7B65DD97791CDDDDAA449CB091F9D6CAF551674FA18668B35CFD30774CAD7099AC3B15ED649803C8878E38A895FC2B7401E3CBE8C4AA3344B9A5FF0F3244EF4EE982CEE52B75C37A62F5779B9AE988CD83CDA06B5A655B9FC723651B993F65D6B934E88DA786654AE1B26D7F196EDF806BCBCA95EBAF60F4CC8F64AE46504EA342A6705D6307C1A77F2FC1BD413C96495C5496E5E9579A8F9039E6CF4AE3B90F643220E6A2A23418DA162D2F1478D4255314950B7CBFD5326D874E2121A3301B11E231335698CD7BEC804C8631F5B64B1DE783BE322FE86DD4D920916A3B9368B2CD3345F83441976879E5BBDF5B07EF9476F3ED7ECE6A858932F14211BC069EDDAC98C29D5D62E36055509E9ECB5B461321C4893B0E1BAA96ECD0457E3764181BA7635F886952015B368EFA84266F21CF1A10B3C723407BCC04C0CC3F0EB0ADF97C6055961AC537501CCAF275754C730344E3377AECE35C318AAF6D630044474102C80A118F21C35710BC29885359378B532B0199E784A0EC39951A89093B798C230666993AD5AA831F8BA8117B32AC333D5566DB208239B300C508ECDEDCCCC9A09ACBA6832D3AC9234DF129E651E783211D819454FB38CD131B1998C9E55492D6CEEA659D7218E3F52CE3CB399BFA0B36531954C94998D8CB41151456FF1EF819CB3D520DE4D1C2037BD8E70C6E39D0501D6899C97E331CDEFED3658D7C7E3F166AD8EC7136C5BD66E3C796ACB3A641D23CACCF5B057D7E76238156EE279DBD4A06310F9CEF4F0D333F16CEF06F6DCB63D6FC73D11A45B8F56299E16E46A6644FD89DE75B4440FE46CEA2C93FD09DF1D16587973D2249DFEF9704B93DF01EB7A75330A4440EBB20E0ED406BE36BA19C5604826E1ED64E41193DE06FAABDB10BCFD6EB76620469DEF303A7B185885AAFA513CBDEAF492AA677475552DADBA4CBC6B2EFB45558129E31CBC8D3901B20754BFC77EEE4120EDEAA338622CE91E578266993CF814478CB038395B569EFE99551DA378B025E30B41DE8F444E7B04122DA956E7FA73F2A66C5C2B2960D522D713FBF91C5B4B6F3EDD90E39CD83095F9CBEDD79FFDC8900EFC809DFC97D54EFD58F3235D3319B0267A15A7C5BF01344EF56EA493B4DA89339D923B4870988A7A6B89B75332253A38555394BDF212BF47CAA47982C01F073A45F15D0A6BA5B6E3C9513DF92B94323A75F48C4EE2058C9F487338214FE2CDC8B1D6F1E4624CB42719A407904F35D21CE4E1BD52A529A546FF891FE3E60CE6E31D32A4EAEAB4CE588A2893E7629FF5C9A841F0E589F62B3F44F250617966758315A7C5C2C3C9C5BC5E9A146441B7A5CD37DDAEB421235B5E8B46FFF6C9B9D8082E8FB94EA5ED55A60455B6A494CAA976F10993EA5CEC53954632E99E58AA9D1F40BDAF7CA337DEABFDED099313BD8EB2F5F25326D516B5AA4721265B79603731F1CE99A834BD10DAD24B49A6B89F32F97815902D61AEEE787FAF1CD4B93E62583109FA7DAC5D0586E7273D9FF9E126877D0E46D1C1C5F0502C2B4581CF3059D74C12C521E7650D931033B13AD4AEFEFC8C49EC0A3AE4FA2B65B2643B3E39AB5D0372BF37A8CA442AA7E3B3DA454C50334DCF2AA4F349EDC296020D93EB23936C3FBD7E491A36E0B8603F9DEE1B2636EC9413AB04851D9990BF159F0E9FAEFCB655335FC6276582CD0A75EC0DB98B6DB24549129DB16D5CCAE63BB64EBDFBEEE571E8ACF10D873F31277106142518B2C363C8351A19EAA9587F3BA0620F5F9509D902BA42636CE0748715793A413EC4A26F0A1E9FC16F18CA480D9B3CF66D7150E05F7FCD548DA6AED4908F46A3656D684A667A8903DDDE3486483259E3AFFB03157AD5EACB655319C57434EF828E51E6A28BE1F5618A6C4749E60B1AAAEC174D4324EF86C2057F3E1AF90932C1014E74D533C1B08F65BF1F2D6843DBCB2516887DDD8B2801F8DDAFD4AE164F10A8CC793437E271B901E76812C66D59A138D67BCFB329A03F9E8CFE14C16E26FBCDDA533693528D0B1586CD4055756FA83EF28D097C365999A8318DC737F875186F8A2F3DF00782DD569D8365584A09870939799011F0EDD4927BB1976C69536128FC891609D4B3A93B3B159A39D278C3C41DD8960A3CF2D6167EC152BBC3F230DCE0182C0C8B1F7756DC97414CBC5E78AD61679ABA493DFD3AD815A1CED68E8D216C0BA3FA0A575B10F6FFF8AC1F0B5926A1BAF5A8D7124AAD636B431A413A86712BF7CD79B95CFA50203EEED07B72A8178FBCD2C6319139A9CB649864993C2788460566B666B08E33D380C2CCE26F5B97797CA864DE86F9B7353A25C96C1C1EFBB3999CD31E6091B8060D41F235F5EBC6FAA91269D1A2C5BF098EAEEBBE4AA1E0183A994D616A52E8C578DB510585309421451CCA50C844312D3938564AA19D51C86574E6CBE83AA192C13E9161DD4986F9898C73C377E66A9A96A8140E3D0A8585A16BC614DA3E9D10CB1D0A6120438AD295891C4E51FC94C238A3D01214C51B52A82632BA3C63163E2F23933252DF3DC860DD838C011C6468BE2D65981FCB786ACB302D5AB4784CBC7BF62BBC7EF6ECD96FF0FED9AB671FE00D5EBF7BFE1C83F74D945FD9AFEA497CC4AFF57FDE63822702F6ECC58BDF7E7DFD3386BFA9EFFE78F1EB8717BFE3F5FB576F5FBC78F5A68EF4B7FA67C3E4DDBB1784DF2497D7EF7EFAE5DD0FCAF82760FFC50CFDF9FA0F80377FC087B7F0E2D98B5774FFD50B80B72FAA38BFFEFCEEE7B7F5D4E25FD53DF597FFC0FBB7CF3EBCFAEFD361F23FC8E4EFD7FFFBEEDDB3373593FFBC7BFB015EFDF1EEDD6FAFAB386FFE7EF1E78BD32535F5EDB3E76FE0F58BE7F0FC099549C5E4EFDFFEC4565131F9E9C387F7F0EAD9EFCF6A2258266F7FFEE99409FBF0E25DD5529E12935FEADAF51766ED393279D7D4AED7CF9A66725A26BFFF24FF50ED223CFFE5D9A367F99FF0E1F79FDEBE79FF37B0DF5EBDFFCFCF3FBD7AFDD79F3FFDF4FB07FA94BD7B5EC7F953FDB9299F0F181FF1166BD77BBCFAE3178AFDD78FCAFC399E63A618BE7EF58DFAFCF9F3F7F01AC3E7AFDF63D6DF37D97FC3DEB093F8CF2909269017CF65A2162D5AB468D1A2458B162D5AFC10FC1F5662391D7559A2490000000049454E44AE426082,	47,	'20180511 00:59:46.643',	1,	'Single')
) as v ([DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType]);


SET IDENTITY_INSERT #dbo_Documents OFF;

SET IDENTITY_INSERT [dbo].[Documents] ON;


WITH cte_data as (SELECT CAST([DocumentID] AS int) AS [DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType] FROM [#dbo_Documents])
MERGE [dbo].[Documents] as t
USING cte_data as s
	ON t.[DocumentID] = s.[DocumentID]
WHEN NOT MATCHED BY target THEN
	INSERT ([DocumentID], [DocumentName], [DocumentBytes], [UserID], [CreatedOn], [ExpenseID], [DocumentType])
	VALUES (s.[DocumentID], s.[DocumentName], s.[DocumentBytes], s.[UserID], s.[CreatedOn], s.[ExpenseID], s.[DocumentType])
WHEN MATCHED THEN 
	UPDATE SET 
	[DocumentName] = s.[DocumentName], [DocumentBytes] = s.[DocumentBytes], [UserID] = s.[UserID], [CreatedOn] = s.[CreatedOn], [ExpenseID] = s.[ExpenseID], [DocumentType] = s.[DocumentType]
WHEN NOT MATCHED BY source THEN
	DELETE
;

SET IDENTITY_INSERT [dbo].[Documents] OFF;

DROP TABLE #dbo_Documents;

-- End data of table: [dbo].[Documents] --
END
GO
