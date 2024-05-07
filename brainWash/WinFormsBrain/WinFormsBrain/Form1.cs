using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBrainWash
{
    public partial class Form1 : Form
    {
        string[,] a = null;
        int PlaceOfWord = 0;
        int NumToCount = 0;
        int Stop = 0;
        int chose = 0;
        int wordfoundToButton = 0;
        int WordFoundInGame = 0;
        int StartGame = 0;
        public int CurrectTranslate = 0;
        public int start = 0;
        public int end = 0;
        public int Chose = 0;
        public string[,] unitEng;
        public int CheckedWord = 0;
        //    public string[] wsss2 = new string[]
        // { "[ 'ACTRESS', 'שחקנית (בהצגה או סרט)', '1'],", "['15374', 'ADORN', 'לקשט', '2'],", "['15375', 'AGENDA', 'סדר יום', '3'],", "['15376', 'AIR CONDITIONER', 'מזגן', '1'],", "['15377', 'ALGAE', 'אצות', '3'],", "['15378', 'ANTLER', 'קרן', '3'],", "['15379', 'AUTOMOBILE', 'כלי רכב, אוטו', '1'],", "['15380', 'BASS', 'בס (במוזיקה)', '1'],", "['15381', 'BEAD', 'חרוז', '3'],", "['15382', 'BEAK', 'מקור', '3'],", "['15383', 'BEE', 'דבורה', '1'],", "['15384', 'BELL', 'פעמון', '1'],", "['15385', 'BERRY', 'גרגרי יער', '1'],", "['15386', 'BLADE', 'להב', '1'],", "['15387', 'BLAME', 'להאשים', '1'],", "['15388', 'BLANKET', 'שמיכה', '1'],", "['15389', 'BLEAK', 'עגום', '3'],", "['15390', 'BLEW', 'נשב (רוח), ניפח, פוצץ', '3'],", "['15391', 'BRICK', 'לבנה', '1'],", "['15392', 'BULLY', 'בריון', '2'],", "['15393', 'BUTTERFLY', 'פרפר', '1'],", "['15394', 'CADAVER', 'גופה', '3'],", "['15395', 'CAMEL', 'גמל', '1'],", "['15396', 'CANCEL', 'לבטל', '1'],", "['15397', 'CANDY', 'ממתק', '1'],", "['15398', 'CANVASS', 'לבדוק, לסקור', '3'],", "['15399', 'CARPET', 'שטיח', '3'],", "['15400', 'CASH', 'מזומן', '1'],", "['15401', 'CASH', 'לפדות', '1'],", "['15402', 'CASHIER', 'קופאי', '2'],", "['15403', 'CASINO', 'קזינו', '1'],", "['15404', 'CATERPILLAR', 'זחל', '3'],", "['15405', 'CAVE', 'מערה', '1'],", "['15406', 'CAVIAR', 'קוויאר', '3'],", "['15407', 'CEREAL', 'דגני בוקר', '3'],", "['15408', 'CIGARETTE', 'סיגריה', '1'],", "['15409', 'CITRUS', 'פרי הדר', '3'],", "['15410', 'CLAY', 'חימר', '2'],", "['15411', 'CLOUD', 'ענן', '1'],", "['15412', 'CLUB', 'מועדון', '1'],", "['15413', 'COCKROACH', 'מקק, ג&#39;וק', '3'],", "['15414', 'COFFIN', 'ארון מתים', '3'],", "['15415', 'COLOGNE', 'קולון, בושם (של גבר)', '3'],", "['15416', 'COMPOST', 'זבל אורגני', '1'],", "['15417', 'CONDUCTOR', 'מנצח (תזמורת)', '3'],", "['15418', 'CONQUISTADOR', 'כובש', '3'],", "['15419', 'CONSONANT', 'עיצור (לשון)', '3'],", "['15420', 'COOP', 'לכלוא', '1'],", "['15421', 'COOP', 'לול', '2'],", "['15422', 'COPPER', 'נחושת', '3'],", "['15423', 'COTTON', 'כותנה', '1'],", "['15424', 'COUGAR', 'פומה, סוג של טורף', '3'],", "['15425', 'COUPON', 'קופון', '1'],", "['15426', 'CUCUMBER', 'מלפפון', '1'],", "['15427', 'CULMINATE', 'הגיע לשיא', '2'],", "['15428', 'CZAR', 'צאר (שליט רוסי)', '3'],", "['15429', 'DART', 'חץ', '1'],", "['15430', 'DATE', 'תאריך', '1'],", "['15431', 'DATE', 'תמר', '2'],", "['15432', 'DATE', 'יציאה, פגישה, דייט', '1'],", "['15433', 'DEAD SEA', 'ים המלח', '1'],", "['15434', 'DENOMINATOR', 'מכנה (של שבר)', '2'],", "['15435', 'DENTAL', 'שקשור בשיניים', '1'],", "['15436', 'DENTIST', 'רופא שיניים', '1'],", "['15437', 'DIARY', 'יומן', '1'],", "['15438', 'DICTATOR', 'עריץ, דיקטטור', '1'],", "['15439', 'DILEMMA', 'דילמה, בעיה', '1'],", "['15440', 'DIURNAL', 'יומי', '3'],", "['15441', 'DIVORCE', 'גירושין', '1'],", "['15442', 'DOORSTEP', 'מפתן הדלת', '2'],", "['15443', 'DOVECOTE', 'שובך', '3'],", "['15444', 'DUST', 'אבק, לאבק', '1'],", "['15445', 'DUTCH', 'הולנדי', '3'],", "['15446', 'DWARF', 'לגמד, גמד', '3'],", "['15447', 'DWINDLE', 'הידלדל, התמעט', '3'],", "['15448', 'EAGLE', 'נשר', '1'],", "['15449', 'ECHO', 'הד', '1'],", "['15450', 'EDIBLE', 'אכיל', '2'],", "['15451', 'EEL', 'צלופח', '3'],", "['15452', 'ELEPHANT', 'פיל', '1'],", "['15453', 'ENVELOPE', 'מעטפה', '1'],", "['15454', 'EXOTIC', 'אקזוטי, מארץ זרה', '1'],", "['15455', 'EXPLOSIVE', 'חומר נפץ', '1'],", "['15456', 'FAIRY', 'פיה', '1'],", "['15457', 'FAIRYTALE', 'אגדה', '1'],", "['15458', 'FAN', 'מאוורר, לאוורר', '1'],", "['15459', 'FAN', 'מעריץ, אוהד', '1'],", "['15460', 'FANCY', 'מגונדר', '1'],", "['15461', 'FANCY', 'מחבב', '2'],", "['15463', 'FASHION', 'לעצב', '1'],", "['15462', 'FASHION', 'אופנה', '1'],", "['15464', 'FILMMAKER', 'יוצר סרטים', '1'],", "['15465', 'FILTER', 'פילטר, מסנן', '1'],", "['15466', 'FISHERMAN', 'דייג', '1'],", "['15467', 'FISHING', 'דיג', '1'],", "['15468', 'FLIMSY', 'עדין, שביר', '2'],", "['15469', 'FOLK', 'עממי', '3'],", "['15470', 'FOLKLORE', 'פולקלור', '3'],", "['15471', 'FOOL', 'טיפש, לשטות במישהו', '1'],", "['15472', 'FOOTAGE', 'קטע צילום', '1'],", "['15473', 'FOREST', 'יער', '1'],", "['15474', 'FORGIVE', 'לסלוח', '1'],", "['15475', 'FORK', 'מזלג', '1'],", "['15476', 'FORMULA', 'נוסחה, פורמולה', '1'],", "['15477', 'FORMULATE', 'לנסח', '1'],", "['15478', 'FRATERNAL', 'אחוותי, של אחים', '3'],", "['15479', 'FROG', 'צפרדע', '1'],", "['15480', 'FURNISH', 'לרהט', '3'],", "['15481', 'GARBAGE', 'זבל', '1'],", "['15482', 'GARDEN', 'גן', '1'],", "['15483', 'GARLIC', 'שום', '3'],", "['15484', 'GATE', 'שער', '1'],", "['15485', 'GIFT', 'מתנה', '1'],", "['15486', 'GLACIER', 'קרחון', '2'],", "['15487', 'GLAND', 'בלוטה', '3'],", "['15489', 'GLASS', 'זכוכית', '1'],", "['15488', 'GLASS', 'כוס', '1'],", "['15490', 'GLAZE', 'זיגוג', '3'],", "['15491', 'GLOVE', 'כפפה', '1'],", "['15492', 'GOLDEN', 'מוזהב', '1'],", "['15493', 'GRAMMATICAL', 'דקדוקי', '1'],", "['15494', 'GRAPES', 'ענבים', '1'],", "['15495', 'GRIT', 'גרגרים, לכלוך', '3'],", "['15496', 'GROCERY', 'מכולת', '3'],", "['15498', 'GROOM', 'חתן', '3'],", "['15497', 'GROOM', 'לטפח, לטפל', '3'],", "['15499', 'GUILLOTINE', 'גיליוטינה', '3'],", "['15500', 'GULF WAR', 'מלחמת המפרץ', '3'],", "['15501', 'GYM', 'אולם ספורט', '1'],", "['15502', 'GYMNASIUM', 'אולם ספורט', '1'],", "['15503', 'HANDICAP', 'נכה', '3'],", "['15504', 'HARMONY', 'הרמוניה', '1'],", "['15505', 'HEART', 'לב', '1'],", "['15506', 'HEARTBEAT', 'דופק, פעימות לב', '1'],", "['15507', 'HEROINE', 'גיבורה', '2'],", "['15508', 'HILARIOUS', 'מצחיק', '1'],", "['15509', 'HILL', 'גבעה', '1'],", "['15510', 'HORN', 'קרן (של בע&QUOT;ח)', '1'],", "['15511', 'HORN', 'צופר', '2'],", "['15512', 'HOUSEMAID', 'עוזרת בית, מנקה', '2'],", "['15513', 'HOWL', 'יללה, לילל', '1'],", "['15514', 'INDEX', 'אינדקס, תוכן עניינים', '1'],", "['15515', 'INEXPENSIVE', 'לא יקר, זול', '1'],", "['15516', 'INN', 'פונדק', '3'],", "['15517', 'INTENSE', 'עז, אינטנסיבי', '3'],", "['15519', 'INTOXICATE', 'להלהיב', '3'],", "['15518', 'INTOXICATE', 'להרעיל, לשכר', '3'],", "['15520', 'INTUITION', 'אינטואיציה', '3'],", "['15521', 'INVERTEBRATE', 'חסר-חוליות', '3'],", "['15522', 'IVORY', 'שנהב', '2'],", "['15523', 'JANITOR', 'שרת', '3'],", "['15524', 'JOG', 'ריצה, ג&#39;וגינג, לרוץ', '3'],", "['15525', 'JOKE', 'בדיחה', '1'],", "['15526', 'JUG', 'כד, קנקן', '3'],", "['15527', 'JUICE', 'מיץ', '1'],", "['15528', 'JUNGLE', 'ג&#39;ונגל', '1'],", "['15529', 'JUNKYARD', 'מגרש גרוטאות', '2'],", "['15530', 'KETTLE', 'קומקום', '1'],", "['15531', 'KITE', 'עפיפון', '2'],", "['15532', 'LAKE', 'אגם', '1'],", "['15533', 'LAME', 'צולע', '2'],", "['15534', 'LAUNDER', 'לכבס', '2'],", "['15535', 'LEAF (LEAVES)', 'עלה (עלים)', '1'],", "['15536', 'LEAGUE', 'ליגה', '1'],", "['15537', 'LEAGUE', 'מידת אורך קדומה', '2'],", "['15538', 'LENIENCY', 'חמלה, רחמים', '3'],", "['15539', 'LEOPARD', 'נמר', '3'],", "['15540', 'LIFESTYLE', 'אורח חיים', '1'],", "['15541', 'LIP', 'שפה', '1'],", "['15542', 'LIVER', 'כבד', '1'],", "['15543', 'LOAN', 'הלוואה', '2'],", "['15544', 'LOATHE', 'לתעב', '3'],", "['15545', 'LOYALTY', 'נאמנות', '1'],", "['15546', 'LUCK', 'מזל', '1'],", "['15547', 'LUNCH', 'ארוחת צהריים', '1'],", "['15548', 'MADE', 'עשה', '1'],", "['15549', 'MAGICAL', 'קסום', '1'],", "['15550', 'MAGNIFICENT', 'מדהים', '1'],", "['15551', 'MAKE SURE', 'להבטיח, לוודא', '1'],", "['15552', 'MAKEUP', 'איפור', '1'],", "['15553', 'MARBLE', 'גוּלָּה', '3'],", "['15554', 'MARBLE', 'שיש', '3'],", "['15555', 'MARSUPIAL', 'חיית כיס', '3'],", "['15556', 'MATHEMATICIAN', 'מתמטיקאי', '1'],", "['15557', 'MIRACLE', 'נס, פלא', '1'],", "['15558', 'MOCK', 'ללעוג', '1'],", "['15559', 'MONK', 'נזיר', '2'],", "['15560', 'MONKEY', 'קוף', '1'],", "['15561', 'MONSTER', 'מפלצת', '1'],", "['15562', 'MOOD', 'מצב רוח', '1'],", "['15563', 'MOSQUITO', 'יתוש', '1'],", "['15564', 'MOTH', 'עש', '2'],", "['15565', 'MOUSE (MICE)', 'עכבר (עכברים)', '1'],", "['15566', 'MOUTH', 'פה', '1'],", "['15567', 'NAUSEA', 'בחילה', '3'],", "['15568', 'NICKNAME', 'כינוי חיבה', '1'],", "['15569', 'NO LONGER', 'לא עוד', '3'],", "['15570', 'NUMERATOR', 'מונה (של שבר)', '3'],", "['15571', 'NUMERIC', 'מספרי', '1'],", "['15572', 'NUT', 'אגוז', '1'],", "['15573', 'OCTOPUS', 'תמנון', '1'],", "['15574', 'ODE', 'שיר הלל', '3'],", "['15575', 'OLIVE', 'זית', '1'],", "['15576', 'ONION', 'בצל', '1'],", "['15577', 'ORCHESTRA', 'תזמורת', '3'],", "['15578', 'ORCHESTRATE', 'לתאם, לתזמר', '3'],", "['15579', 'OVEN', 'תנור בישול', '3'],", "['15580', 'OVERHAUL', 'שיפוץ, אוברול', '3'],", "['15581', 'PAD', 'לרפד', '3'],", "['15583', 'PADDLE', 'משוט, דוושה', '1'],", "['15582', 'PADDLE', 'מחבט', '3'],", "['15584', 'PAN', 'מחבת', '3'],", "['15585', 'PARADOX', 'סתירה, פרדוקס', '1'],", "['15586', 'PATHOLOGY', 'פתולוגיה, ענף ברפואה', '1'],", "['15587', 'PEACH', 'אפרסק', '1'],", "['15588', 'PEPPER', 'פלפל', '2'],", "['15589', 'PERCH', 'ענף', '3'],", "['15590', 'PERCH', 'נח, ישב על ענף', '3'],", "['15591', 'PET', 'חיית מחמד', '1'],", "['15592', 'PHARMACY', 'בית מרקחת', '3'],", "['15593', 'PHILOSOPHY', 'פילוסופיה', '1'],", "['15594', 'PHOTOGRAPH', 'צילום, לצלם', '1'],", "['15595', 'PHYSICAL', 'פיזי, גופני', '1'],", "['15596', 'PHYSICIST', 'פיזיקאי', '1'],", "['15597', 'PICK', 'מפרט לגיטרה', '2'],", "['15598', 'PICK', 'לקטוף, לבחור', '1'],", "['15599', 'PIGEON', 'יונה', '2'],", "['15600', 'PINCH', 'לצבוט', '3'],", "['15601', 'PIT', 'בור', '3'],", "['15602', 'PLASTER', 'טיח', '3'],", "['15603', 'POOL', 'בריכה', '1'],", "['15604', 'POTHOLE', 'מהמורה, בור', '3'],", "['15605', 'POTTERY', 'קדרות', '2'],", "['15606', 'POULTRY', 'עוף', '3'],", "['15607', 'PRANK', 'מתיחה', '1'],", "['15608', 'PREGNANCY', 'הריון', '1'],", "['15609', 'PREGNANT', 'הרה (בהריון)', '1'],", "['15610', 'PREHISTORIC', 'קדמון, פרה-היסטורי', '1'],", "['15611', 'PREPARATION FOR', 'הכנות לקראת', '1'],", "['15612', 'PRESENTATION', 'מצגת', '1'],", "['15613', 'PRICK', 'לדקור', '3'],", "['15614', 'PRINTER', 'מדפסת, דַּפָּס', '1'],", "['15615', 'PROPAGANDA', 'תעמולה', '3'],", "['15616', 'PROWESS', 'מיומנות, יכולת', '3'],", "['15617', 'PURSE', 'ארנק', '3'],", "['15618', 'QUARRELSOME', 'וכחני', '3'],", "['15619', 'RAIN', 'גשם', '1'],", "['15620', 'RAINBOW', 'קשת', '1'],", "['15621', 'RAINFALL', 'ירידת גשמים', '1'],", "['15622', 'RAINSTORM', 'סערת גשמים', '1'],", "['15623', 'RAT', 'עכברוש', '1'],", "['15624', 'REDHEAD', 'ג&#39;ינג&#39;י (סלנג)', '1'],", "['15625', 'REHEARSAL', 'חזרה', '1'],", "['15626', 'REHEARSE', 'לחזור, לתרגל', '1'],", "['15627', 'REINCARNATION', 'גלגול נשמות', '3'],", "['15628', 'RESTAURANT', 'מסעדה', '1'],", "['15629', 'RESURGENCE', 'תחייה', '3'],", "['15630', 'RETROACTIVE', 'רטרואקטיבי, למפרע', '3'],", "['15631', 'RHYME', 'חרוז', '1'],", "['15632', 'RICE', 'אורז', '1'],", "['15633', 'RIDE', 'רכיבה, לרכוב', '1'],", "['15634', 'RING', 'זירה', '2'],", "['15635', 'RING', 'טבעת', '1'],", "['15636', 'RING, RANG', 'לצלצל, צלצל', '1'],", "['15637', 'ROAST', 'לקלות, צלי', '3'],", "['15638', 'ROBBERY', 'שוד', '1'],", "['15639', 'ROBE', 'חלוק', '3'],", "['15640', 'ROOF', 'גג', '1'],", "['15642', 'RUBBISH', 'שטויות', '2'],", "['15641', 'RUBBISH', 'זבל', '2'],", "['15643', 'RUN, RAN', 'לרוץ, רץ', '1'],", "['15644', 'SAGA', 'סיפור, סאגה', '1'],", "['15645', 'SALT', 'מלח', '1'],", "['15646', 'SARCOPHAGUS', 'ארון קבורה קדום', '3'],", "['15647', 'SAVANNA', 'ערבה, סוואנה', '3'],", "['15648', 'SCRIPT', 'תסריט', '2'],", "['15649', 'SEAFOOD', 'פירות ים', '1'],", "['15650', 'SEAT', 'מושב, להושיב', '1'],", "['15651', 'SECRET', 'סוד', '1'],", "['15652', 'SENTIMENTS', 'רגשות', '3'],", "['15653', 'SHADOW', 'צל, להאפיל', '1'],", "['15654', 'SHAVE', 'גילוח, לגלח', '2'],", "['15655', 'SHELF (SHELVES)', 'מדף (מדפים)', '2'],", "['15656', 'SHEPHERD', 'רועה צאן', '3'],", "['15657', 'SHINGLES', 'רעף', '3'],", "['15659', 'SHOP', 'לקנות', '1'],", "['15658', 'SHOP', 'חנות', '1'],", "['15660', 'SHOULDER', 'כתף', '1'],", "['15661', 'SHOW', 'הופעה', '1'],", "['15662', 'SHOW', 'להראות', '1'],", "['15663', 'SHY', 'ביישן', '1'],", "['15664', 'SILK', 'משי', '3'],", "['15665', 'SILKWORM', 'תולעת משי', '3'],", "['15666', 'SINGER', 'זמר', '1'],", "['15667', 'SIR', 'אדון, תואר אצולה אנגלי', '1'],", "['15668', 'SKY', 'שמיים, רקיע', '1'],", "['15669', 'SMOG', 'ערפיח', '2'],", "['15670', 'SMOKE', 'עשן, לעשן', '1'],", "['15671', 'SNAKE', 'נחש', '1'],", "['15672', 'SNAP', 'במהירות (סלנג)', '2'],", "['15673', 'SNAP', 'להישבר', '2'],", "['15674', 'SNARL', 'לרטון, לנחור', '3'],", "['15675', 'SNEEZE', 'להתעטש', '1'],", "['15676', 'SNOW', 'שלג', '1'],", "['15677', 'SOCCER', 'כדורגל', '1'],", "['15678', 'SOLD', 'מכר', '1'],", "['15679', 'SOUTH', 'דרום', '1'],", "['15680', 'SOUTHERN', 'דרומי', '1'],", "['15681', 'SPECK', 'כתם', '3'],", "['15682', 'SPIDER', 'עכביש', '1'],", "['15683', 'SPINACH', 'תרד', '3'],", "['15684', 'SPONSOR', 'נותן חסות', '1'],", "['15685', 'SPONTANEOUS', 'ללא מחשבה', '1'],", "['15687', 'SPREAD', 'ממרח, למרוח', '1'],", "['15686', 'SPREAD', 'התפשטות, פיזור', '1'],", "['15688', 'SPY', 'מרגל, לרגל', '1'],", "['15689', 'STAIRCASE', 'גרם מדרגות', '1'],", "['15690', 'STALK', 'לעקוב, להטריד', '3'],", "['15691', 'STAR', 'כוכב, לככב', '1'],", "['15693', 'STAUNCH', 'חזק, מוצק', '3'],", "['15692', 'STAUNCH', 'לעצור, לחסום', '3'],", "['15694', 'STEAL', 'לגנוב', '1'],", "['15695', 'STEREOTYPE', 'סטריאוטיפ', '1'],", "['15696', 'STICKY', 'דביק', '1'],", "['15697', 'STOVE', 'תנור, כיריים', '3'],", "['15699', 'STROKE', 'ליטוף', '3'],", "['15698', 'STROKE', 'מכה', '1'],", "['15700', 'STROKE', 'שבץ/אירוע מוחי', '3'],", "['15701', 'STUDIO', 'סטודיו', '1'],", "['15702', 'STUFF', 'דברים', '1'],", "['15703', 'STUFF', 'למלא, לפחלץ', '3'],", "['15704', 'STUNT', 'פעלול', '1'],", "['15705', 'STUPID', 'טיפש', '1'],", "['15706', 'SUBTRACTION', 'חיסור (חשבון)', '3'],", "['15707', 'SUGAR', 'סוכר', '1'],", "['15708', 'SWEET', 'מתוק, ממתק', '1'],", "['15709', 'SWEPT AWAY', 'נסחף', '2'],", "['15710', 'SWINDLER', 'רמאי', '3'],", "['15711', 'SWORD', 'חרב', '1'],", "['15712', 'SYLLABLE', 'הברה', '3'],", "['15713', 'SYNDROME', 'תסמונת', '1'],", "['15714', 'SYRUP', 'סירופ', '3'],", "['15715', 'TALE', 'סיפור, אגדה', '1'],", "['15716', 'TASTE', 'טעם, לטעום', '1'],", "['15717', 'TAX', 'מס', '1'],", "['15718', 'TEETH, TOOTH', 'שיניים, שן', '1'],", "['15719', 'TENT', 'אוהל', '1'],", "['15720', 'THANK', 'תודה, להודות', '1'],", "['15721', 'THEATER', 'תיאטרון', '1'],", "['15722', 'THEATER', 'בית קולנוע', '1'],", "['15723', 'THEORETICALLY', 'תיאורטית, לכאורה', '1'],", "['15724', 'THEORY', 'תיאוריה', '1'],", "['15725', 'THIMBLE', 'אצבעון (לתפירה)', '2'],", "['15726', 'THROUGH', 'דרך, מבעד', '2'],", "['15727', 'THROUGHOUT', 'במשך, בכל', '2'],", "['15728', 'THROW', 'לזרוק, זריקה', '1'],", "['15729', 'TICKET', 'כרטיס', '1'],", "['15730', 'TIMELINE', 'ציר זמן', '1'],", "['15731', 'TIN', 'בדיל, עשוי מפח', '3'],", "['15732', 'TINY', 'קטנטן', '1'],", "['15733', 'TOAD', 'קרפדה', '3'],", "['15734', 'TOES', 'בהונות', '1'],", "['15735', 'TONGUE', 'לשון', '1'],", "['15736', 'TREASURE', 'אוצר, לנצור', '1'],", "['15737', 'TREAT', 'להתייחס', '2'],", "['15738', 'TREAT', 'פינוק, ממתק', '2'],", "['15739', 'TREAT', 'לפנק', '2'],", "['15740', 'TREATMENT', 'טיפול', '1'],", "['15741', 'TREATY', 'אמנה,הסכם, חוזה', '2'],", "['15742', 'TRIGGER', 'הדק', '1'],", "['15743', 'TRIGGERED', 'גרם, עורר, הוביל ל-', '2'],", "['15744', 'TRIM', 'לגזום', '2'],", "['15745', 'TRIPLE', 'פי 3', '1'],", "['15746', 'TRUCK', 'משאית, קרון משא', '1'],", "['15747', 'TUTOR', 'מורה פרטי, להדריך', '2'],", "['15748', 'TWIG', 'ענף קטן, זרד', '3'],", "['15749', 'TWINS', 'תאומים', '1'],", "['15750', 'UGLY', 'מכוער', '1'],", "['15751', 'UNATTRACTIVE', 'לא מושך', '1'],", "['15752', 'UNCLE', 'דוד', '1'],", "['15753', 'UNCONCERNED', 'לא מודאג', '1'],", "['15754', 'UNCRITICAL', 'לא ביקורתי', '1'],", "['15755', 'UNEARTH', 'לחשוף, לחפור', '2'],", "['15756', 'UNFAIR', 'לא הוגן', '1'],", "['15757', 'UNHOLY', 'לא קדוש, לא מוסרי', '1'],", "['15758', 'UNWANTED', 'לא רצוי', '1'],", "['15759', 'UPBRINGING', 'גידול, חינוך', '3'],", "['15760', 'UPHOLSTERY', 'ריפוד', '3'],", "['15761', 'USHER', 'סדרן', '3'],", "['15762', 'USING UP', 'לכלות, לנצל עד תום', '3'],", "['15763', 'VACATION', 'חופשה', '1'],", "['15764', 'VERTEBRATE', 'בעל חוליות', '3'],", "['15765', 'VEST', 'אפודה', '2'],", "['15766', 'VICTORY', 'ניצחון', '1'],", "['15767', 'VILLAIN', 'רשע, נבל', '1'],", "['15768', 'VINEGAR', 'חומץ', '3'],", "['15769', 'VIPER', 'צפע', '3'],", "['15770', 'VOCIFEROUS', 'רעשני', '2'],", "['15771', 'VOWEL', 'תנועה (לשון)', '3'],", "['15772', 'WALL', 'קיר', '1'],", "['15773', 'WART', 'יבלת', '3'],", "['15774', 'WASP', 'צרעה', '1'],", "['15775', 'WATERFALL', 'מפל', '1'],", "['15776', 'WAVE', 'גל', '1'],", "['15777', 'WEAPON', 'נשק', '1'],", "['15778', 'WEAR', 'ללבוש', '1'],", "['15779', 'WEAVE', 'לטוות, לארוג', '3'],", "['15780', 'WEDDING', 'חתונה', '1'],", "['15781', 'WEEKEND', 'סוף שבוע', '1'],", "['15782', 'WELL', 'באר', '2'],", "['15783', 'WELL', 'טוב, היטב', '1'],", "['15784', 'WELL', 'בריא', '2'],", "['15785', 'WHALE', 'לוויתן', '2'],", "['15786', 'WHISTLE', 'משרוקית, לשרוק', '1'],", "['15787', 'WHOLESALE', 'סיטונאות', '3'],", "['15788', 'WIFE', 'אישה, רעיה', '1'],", "['15789', 'WIN', 'ניצחון, לנצח', '1'],", "['15790', 'WOLF (WOLVES)', 'זאב (זאבים)', '1'],", "['15791', 'WORK', 'עבודה, לעבוד', '1'],", "['15792', 'WORM', 'תולעת', '1'],", "['15793', 'WRITER', 'סופר', '1'],", "['15794', 'YAWN', 'לפהק, פיהוק', '3'],", "['15795', 'ZEALOT', 'קנאי, פנט', '3'],};" };
        public int unit = 0;
        public int count = 0;
        int spped;
        int Score;
        public int english = 0;
        public int ten = 0;
        public int cntten = 0;
        public int place = 0;
        PictureBox[] Pics = new PictureBox[8];
        protected string connectionString3 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Downloads\entity\DataWords.mdf;Integrated Security=False;Connect Timeout=30";
        Random Rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnAgain.Hide();
            //   string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
           // string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString3);
            SqlConnection con = new SqlConnection(connectionString3);
            string Select = "SELECT Word FROM AllWords   where  Lang='" + "english" + "' AND Unit='" + 1 + "' And Points <'" + 150 + "'"; ;
           // con.Open();
            MyHelper helper = new MyHelper();
            // DataSet data = helper.GetDataSet(Select, "Table2");
            // SqlConnection connection = ConnectToDb(fileName);//קשר לטבלה
            SqlDataAdapter adapter = new SqlDataAdapter(Select, connection);//מכין אותו לביצוע פעולה
            DataSet data = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                //  adapter.UpdateCommand.Transaction = trans;
                connection.Open();//פתיחת הקשר
                adapter.Fill(data, "Table2");//ימלא את הטבלה בנתונים שיש
            }
            catch { }
            //     DataTable table1= helper.data
            SqlCommand cmd = new SqlCommand(Select, con);
            a = new string[data.Tables[0].Rows.Count, 2];
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                a[i, 0] = data.Tables[0].Rows[i][0].ToString();
            }
            string Select2 = "SELECT Translation FROM AllWords  where  Lang='" + "english" + "' AND Unit='" + 1 + "' And Points <'" + 150 + "'";
            data = helper.GetDataSet(Select2, "Table2");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                Encoding en = Encoding.GetEncoding(1252);
                // string Encode = en.GetString((data.Tables[0].Rows[i][0].ToString()));
                a[i, 1] = data.Tables[0].Rows[i][0].ToString();
                // byte[] bytes = Encoding.GetEncoding(1252).GetBytes((string)reader["Note"]);
                //   string note = Encoding.UTF8.GetString(bytes);
            }
            btnWord.Text = a[0, 0].ToString();
            btnTrans.Text = a[0, 1].ToString();
            PlaceOfWord = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //able
            //150
         
          //  string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString5"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString3);
           // int Unit2 = comboBox2.SelectedIndex + 1;
          //  string Select2 = "UPDATE Table2 SET Points='" + 150 + "' WHERE Lang=" + comboBox1.SelectedItem.ToString() + " AND Unit='" + Unit2 + "' AND Word=" + a[NumToCount, 0].ToString() +"'";
            string updateQuery = "UPDATE AllWords SET Points=@Points1 WHERE Lang=@Lang1 AND Unit=@Unit1 AND Word=@Word1";
            int Unit2 = int.Parse(comboUnit.SelectedItem.ToString());
            using (SqlCommand cmd2 = new SqlCommand(updateQuery, connection))
            {
               // Console.WriteLine(150 + " com=" + comboBox1.SelectedItem.ToString() + " unit=" + Unit2 + " word=" + a[NumToCount, 0].ToString());
                cmd2.Parameters.AddWithValue("@Points1", 150);
                cmd2.Parameters.AddWithValue("@Lang1", comboLang.SelectedItem.ToString()); // Check for null in case nothing is selected
                cmd2.Parameters.AddWithValue("@Unit1", Unit2); // Assuming Unit2 is a string variable
                cmd2.Parameters.AddWithValue("@Word1", a[NumToCount, 0].ToString()); // Assuming a is a multidimensional array

                try
                {
                    connection.Open();
                    int rowsAffected = cmd2.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + rowsAffected);
                    //Console.WriteLine("success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void comboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLang.SelectedItem.ToString() == null || comboUnit.SelectedItem.ToString() == null)
                return;
           // button7.Hide();
           // string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString4"].ConnectionString;
            comboWordCount.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString3);
            string Select = "Select Word from AllWords  Where  Lang='" + comboLang.SelectedItem.ToString() + "' and Unit='" + comboUnit.SelectedItem.ToString() + "' And Points <'" + 150 + "'";
            con.Open();
            MyHelper helper = new MyHelper();
            DataSet data = helper.GetDataSet(Select, "AllWords");
            Console.WriteLine(data);
            SqlCommand cmd = new SqlCommand(Select, con);
            string[,] a = new string[data.Tables[0].Rows.Count, 2];
            for (int i = 0; i <= data.Tables[0].Rows.Count - 1; i++)
            {
                a[i, 0] = data.Tables[0].Rows[i][0].ToString();
            }
            string Select2 = "Select Translation from AllWords  Where  Lang='" + comboLang.SelectedItem.ToString() + "' and Unit='" + comboUnit.SelectedItem.ToString() + "' And Points <'" + 150 + "'";
            data = helper.GetDataSet(Select2, "AllWords");
            for (int i = 0; i <= data.Tables[0].Rows.Count - 1; i++)
            {

                a[i, 1] = data.Tables[0].Rows[i][0].ToString();

            }
            for (int i = 1; i <= data.Tables[0].Rows.Count ; i++)
            {
                comboWordCount.Items.Add(i);
            }
            con.Close();
        }

        private void comboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString3);
            MessageBox.Show("Hello, world!"+ connectionString3, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string Select2 = "Select Unit from tblUintChoosen  Where  IdLang='" + comboLang.SelectedItem.ToString() + "'";
            //connection.Open();
            //   SqlCommand cmd2 = new SqlCommand("CHARACTER SET hebrew", con);
            //cmd2.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(Select2, connection);//מכין אותו לביצוע פעולה
            DataSet data = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                //  adapter.UpdateCommand.Transaction = trans;
                connection.Open();//פתיחת הקשר
                adapter.Fill(data, "tblUintChoosen");//ימלא את הטבלה בנתונים שיש
            }
            catch { }
            finally
            {
                SqlCommand cmd = new SqlCommand(Select2, connection);
                // string[,] a = new string[data.Tables[0].Rows.Count, 2];
                comboUnit.Items.Clear();
                comboWordCount.Items.Clear();
                //comboBox2.Items.Add(1);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    comboUnit.Items.Add(i + 1);
                }
                connection.Close(); 
            }
            // DataSet data = helper.GetDataSet(Select2, "Table2");
            //     DataTable table1= helper.data
          
            
        }
        /*-------------------------------start game---------------------------------------------------------------------------*/
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (comboLang == null || comboUnit == null || comboWordCount == null)
                return;
            if (comboLang.SelectedItem.ToString() == null || comboUnit.SelectedItem.ToString() == null || comboWordCount.SelectedItem.ToString() == null)
                return;
            if (Stop == 1)
            {
                btnStop.Show();
                btnStart.Hide();
                btnKnown.Hide();
                btnWord.Show();
                btnWordCount.Hide();
                timer1.Start();
            }
            else
            { }
            comboLang.Hide();
            comboUnit.Hide();
            comboWordCount.Hide();
            btnTrans4.Hide();
            btnTrans3.Hide();
            btnTrans2.Hide();
            btnAgain.Hide();
            btnStop.Show();
            btnStart.Hide();
            btnKnown.Show();
            btnWord.Show();
            btnWordCount.Hide();
            if (NumToCount == 0)
            {
                btnWord.Text = a[0, 0];
                btnTrans.Text = a[0, 1];
            }
            start = 1;
            string Select = "SELECT Word,Translation,Points FROM AllWords   where  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "'";
            SqlConnection connection = new SqlConnection(connectionString3);
            SqlDataAdapter adapter = new SqlDataAdapter(Select, connection);//מכין אותו לביצוע פעולה
            DataSet data = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                //  adapter.UpdateCommand.Transaction = trans;
                connection.Open();//פתיחת הקשר
                adapter.Fill(data, "AllWords");//ימלא את הטבלה בנתונים שיש
            }
            catch { }
            finally { connection.Close(); }
            dataGridView1.DataSource = data.Tables[0];
            dataGridView1.Refresh();
            //dataGridView1.;
            timer1.Start();
        }
        /*-----------------------------------timer to show words-------------------------------------------------------*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("hiii");
            if (comboWordCount == null)
                return;
            label2.Text = a.GetLength(0).ToString();
            if (a == null)
                return;
            if (btnWord.Text != "Word" && btnWord.Text == a[PlaceOfWord, 0].ToString() && wordfoundToButton == 0 && StartGame == 0)
            {
                if (PlaceOfWord >= a.GetLength(0) - 1)//כי יש 297 מקומוצ ולא 298
                    return;
                btnWord.Text = a[PlaceOfWord + 1, 0].ToString();
                btnTrans.Text = a[PlaceOfWord + 1, 1].ToString();
                NumToCount++;
                PlaceOfWord++;
            }
            if (btnTrans != null && comboWordCount.SelectedItem != null && NumToCount== int.Parse(comboWordCount.SelectedItem.ToString())-1 && wordfoundToButton == 0 && StartGame == 0)//כלומר סיים כמה מילים שבחר
            {
                timer1.Stop();
                btnAgain.Show();
            }
        }
        private static string GetDBPath()
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Navigate to the 'bin\Debug' directory
                string debugDirectory = Path.Combine(baseDirectory, "bin", "Debug");

                // Navigate to the 'entity' directory within 'bin\Debug'
                string entityDirectory = Path.Combine(debugDirectory, "entity");

                // Combine with the database file name
                string dbFilePath = Path.Combine(entityDirectory, "DataWords.mdf");

                return dbFilePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        private void comboWordCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString3);
            //SqlConnection con = new SqlConnection(connectionString);
            string Select = "SELECT Word FROM AllWords   where  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' And Points <'" + 150 + "'"; ;
           // connection.Open();
            MyHelper helper = new MyHelper();
            // DataSet data = helper.GetDataSet(Select, "Table2");
            // SqlConnection connection = ConnectToDb(fileName);//קשר לטבלה
            SqlDataAdapter adapter = new SqlDataAdapter(Select, connection);//מכין אותו לביצוע פעולה
            DataSet data = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                //  adapter.UpdateCommand.Transaction = trans;
                connection.Open();//פתיחת הקשר
                adapter.Fill(data, "AllWords");//ימלא את הטבלה בנתונים שיש
            }
            catch { }
            //     DataTable table1= helper.data
            SqlCommand cmd = new SqlCommand(Select, connection);
            a = new string[data.Tables[0].Rows.Count, 2];
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                a[i, 0] = data.Tables[0].Rows[i][0].ToString();
            }
            string Select2 = "SELECT Translation FROM AllWords   where  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' And Points <'" + 150 + "'"; ;
            data = helper.GetDataSet(Select2, "AllWords");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                Encoding en = Encoding.GetEncoding(1252);
                // string Encode = en.GetString((data.Tables[0].Rows[i][0].ToString()));
                a[i, 1] = data.Tables[0].Rows[i][0].ToString();
                // byte[] bytes = Encoding.GetEncoding(1252).GetBytes((string)reader["Note"]);
                //   string note = Encoding.UTF8.GetString(bytes);
            }
            btnWord.Text = a[0, 0].ToString();
            btnTrans.Text = a[0, 1].ToString();
            PlaceOfWord = 0;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Show();
            Stop = 1;
            // button1.Show();
            //   button2.Show();
            //   button5.Show();
            timer1.Stop();
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            btnTrans2.Show();
            btnTrans3.Show();
            btnTrans4.Show();
            if (StartGame == 0)
                NumToCount = 0;
           // label3.Text = "";
            StartGame = 1;
            btnWord.Text = a[NumToCount, 0];
            timer1.Start();
            btnTrans.Text = "";
            Random rnd = new Random();
            int word = rnd.Next(0, NumToCount + 1);
            CheckedWord = a[NumToCount, 0].Length;
            WordFoundInGame = 0;
            wordfoundToButton = 0;
            while (btnTrans.Text == "" || btnTrans2.Text == "" || btnTrans3.Text == "" || btnTrans4.Text == "")
            {
                if (btnTrans.Text == "")
                {
                    if (CheckedWord % 2 == 0 && wordfoundToButton == 0)
                    {
                        btnTrans.Text = a[NumToCount, 1];
                        wordfoundToButton = 1;
                    }
                    else
                    {
                        word = rnd.Next(start, comboWordCount.Items.Count);
                        btnTrans.Text = a[word, 1];
                    }
                }
                if (btnTrans2.Text == "")
                {
                    if (CheckedWord % 3 == 0 && wordfoundToButton == 0)
                    {
                        btnTrans2.Text = a[NumToCount, 1];
                        wordfoundToButton = 1;
                    }
                    else
                    {
                        word = rnd.Next(start, comboWordCount.Items.Count);
                        btnTrans2.Text = a[word, 1];
                    }
                }
                if (btnTrans3.Text == "")
                {
                    if (CheckedWord % 5 == 0 && wordfoundToButton == 0)
                    {
                        btnTrans3.Text = a[NumToCount, 1];
                        wordfoundToButton = 1;
                    }
                    else
                    {
                        word = rnd.Next(start, comboWordCount.Items.Count);
                        btnTrans3.Text = a[word, 1];
                    }
                }
                if (btnTrans4.Text == "")
                {
                    if (CheckedWord % 1 == 0 && wordfoundToButton == 0)
                    {
                        btnTrans4.Text = a[NumToCount, 1];
                        wordfoundToButton = 1;
                    }
                    else
                    {
                        word = rnd.Next(start, comboWordCount.Items.Count);
                        btnTrans4.Text = a[word, 1];
                    }
                }

                CheckedWord = 0;
            }
            wordfoundToButton = 0;
            if (btnAgain.Text == "Finished")
            {
                this.Controls.Clear();//לניקוי
                InitializeComponent();
                Form1_Load(e, e);

            }
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            if (btnTrans.Text == a[NumToCount, 1])
            {
                SqlConnection connection = new SqlConnection(connectionString3);
                MyHelper helper = new MyHelper();
                string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";
                int point = 0;

                //string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";

                // Assuming connection is an instance of SqlConnection already created
                using (connection = new SqlConnection(connectionString3))
                {
                    using (SqlCommand command = new SqlCommand(cmd3, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Word", btnWord.Text);
                        command.Parameters.AddWithValue("@Translation", btnTrans2.Text);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            // Check if the result is not null and is convertible to an integer
                            if (result != null && int.TryParse(result.ToString(), out int points))
                            {
                                // Use the points value retrieved from the database
                                Console.WriteLine("Points: " + points);
                                point = points;
                                // MessageBox.Show("Hello, world!" + point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception exp)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + exp.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                SqlConnection connection2 = new SqlConnection(connectionString3);
                point = point + 10;
                 MessageBox.Show("Hello, world!"+ point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string Select2 = "UPDATE  AllWords SET Points='" + point + "'  WHERE  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' AND Word='" + a[NumToCount, 0] + "'";
                connection2.Open();


                SqlCommand cmd = new SqlCommand(Select2, connection2);

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch
                { }
                finally
                {
                    connection2.Close();
                }
                if (NumToCount == comboWordCount.SelectedIndex)
                {
                    btnAgain.Text = "Finished";
                }
                WordFoundInGame = 1;
                label3.Text = "CORRECT";
                wordfoundToButton = 1;
                if (WordFoundInGame == 1 && NumToCount < comboWordCount.SelectedIndex)//שיאפס תרגום ולא ימשיך הלאה מעבר למה שצריך
                {
                    NumToCount++;
                    WordFoundInGame = 0;
                    btnWord.Text = "";
                    btnTrans.Text = "";
                    btnTrans2.Text = "";
                    btnTrans3.Text = "";
                    btnTrans4.Text = "";
                    btnAgain_Click(null, null);
                }
            }
            else
                label3.Text = "not correct";
        }

        private void btnTrans2_Click(object sender, EventArgs e)
        {
            if (btnTrans2.Text == a[NumToCount, 1])
            {
                SqlConnection connection = new SqlConnection(connectionString3);
                MyHelper helper = new MyHelper();
                string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";
                int point = 0;

                //string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";

                // Assuming connection is an instance of SqlConnection already created
                using (connection = new SqlConnection(connectionString3))
                {
                    using (SqlCommand command = new SqlCommand(cmd3, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Word", btnWord.Text);
                        command.Parameters.AddWithValue("@Translation", btnTrans2.Text);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            // Check if the result is not null and is convertible to an integer
                            if (result != null && int.TryParse(result.ToString(), out int points))
                            {
                                // Use the points value retrieved from the database
                                Console.WriteLine("Points: " + points);
                                point = points;
                                // MessageBox.Show("Hello, world!" + point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception exp)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + exp.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                SqlConnection connection2 = new SqlConnection(connectionString3);
                point = point + 10;
                // MessageBox.Show("Hello, world!"+ point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string Select2 = "UPDATE  AllWords SET Points='" + point + "'  WHERE  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' AND Word='" + a[NumToCount, 0] + "'";
                connection2.Open();


                SqlCommand cmd = new SqlCommand(Select2, connection2);

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch
                { }
                finally
                {
                    connection2.Close();
                }
                if (NumToCount == comboWordCount.SelectedIndex)
                {
                    btnAgain.Text = "Finished";
                }
                WordFoundInGame = 1;
                label3.Text = "CORRECT";
                wordfoundToButton = 1;
                if (WordFoundInGame == 1 && NumToCount < comboWordCount.SelectedIndex)//שיאפס תרגום ולא ימשיך הלאה מעבר למה שצריך
                {
                    NumToCount++;
                    WordFoundInGame = 0;
                    btnWord.Text = "";
                    btnTrans.Text = "";
                    btnTrans2.Text = "";
                    btnTrans3.Text = "";
                    btnTrans4.Text = "";
                    btnAgain_Click(null, null);
                }
            }
            else
                label3.Text = "not correct";

        }

        private void btnTrans3_Click(object sender, EventArgs e)
        {
            if (btnTrans3.Text == a[NumToCount, 1])
            {
                SqlConnection connection = new SqlConnection(connectionString3);
                MyHelper helper = new MyHelper();
                string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";
                int point = 0;

                //string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";

                // Assuming connection is an instance of SqlConnection already created
                using (connection = new SqlConnection(connectionString3))
                {
                    using (SqlCommand command = new SqlCommand(cmd3, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Word", btnWord.Text);
                        command.Parameters.AddWithValue("@Translation", btnTrans2.Text);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            // Check if the result is not null and is convertible to an integer
                            if (result != null && int.TryParse(result.ToString(), out int points))
                            {
                                // Use the points value retrieved from the database
                                Console.WriteLine("Points: " + points);
                                point = points;
                                // MessageBox.Show("Hello, world!" + point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception exp)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + exp.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                SqlConnection connection2 = new SqlConnection(connectionString3);
                point = point + 10;
                // MessageBox.Show("Hello, world!"+ point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string Select2 = "UPDATE  AllWords SET Points='" + point + "'  WHERE  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' AND Word='" + a[NumToCount, 0] + "'";
                connection2.Open();


                SqlCommand cmd = new SqlCommand(Select2, connection2);

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch
                { }
                finally
                {
                    connection2.Close();
                }
                if (NumToCount == comboWordCount.SelectedIndex)
                {
                    btnAgain.Text = "Finished";
                }
                WordFoundInGame = 1;
                label3.Text = "CORRECT";
                wordfoundToButton = 1;
                if (WordFoundInGame == 1 && NumToCount < comboWordCount.SelectedIndex)//שיאפס תרגום ולא ימשיך הלאה מעבר למה שצריך
                {
                    NumToCount++;
                    WordFoundInGame = 0;
                    btnWord.Text = "";
                    btnTrans.Text = "";
                    btnTrans2.Text = "";
                    btnTrans3.Text = "";
                    btnTrans4.Text = "";
                    btnAgain_Click(null, null);
                }
            }
            else
                label3.Text = "not correct";
        }

        private void btnTrans4_Click(object sender, EventArgs e)
        {
            if (btnTrans4.Text == a[NumToCount, 1])
            {
                SqlConnection connection = new SqlConnection(connectionString3);
                MyHelper helper = new MyHelper();
                string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";
                int point = 0;

                //string cmd3 = "SELECT Points FROM AllWords WHERE Word = @Word AND Translation = @Translation";

                // Assuming connection is an instance of SqlConnection already created
                using (connection = new SqlConnection(connectionString3))
                {
                    using (SqlCommand command = new SqlCommand(cmd3, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Word", btnWord.Text);
                        command.Parameters.AddWithValue("@Translation", btnTrans2.Text);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();

                            // Check if the result is not null and is convertible to an integer
                            if (result != null && int.TryParse(result.ToString(), out int points))
                            {
                                // Use the points value retrieved from the database
                                Console.WriteLine("Points: " + points);
                                point = points;
                                // MessageBox.Show("Hello, world!" + point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception exp)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + exp.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                SqlConnection connection2 = new SqlConnection(connectionString3);
                point = point + 10;
                // MessageBox.Show("Hello, world!"+ point, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string Select2 = "UPDATE  AllWords SET Points='" + point + "'  WHERE  Lang='" + comboLang.SelectedItem.ToString() + "' AND Unit='" + comboUnit.SelectedItem.ToString() + "' AND Word='" + a[NumToCount, 0] + "'";
                connection2.Open();


                SqlCommand cmd = new SqlCommand(Select2, connection2);

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch
                { }
                finally
                {
                    connection2.Close();
                }
                if (NumToCount == comboWordCount.SelectedIndex)
                {
                    btnAgain.Text = "Finished";
                }
                WordFoundInGame = 1;
                label3.Text = "CORRECT";
                wordfoundToButton = 1;
                if (WordFoundInGame == 1 && NumToCount < comboWordCount.SelectedIndex)//שיאפס תרגום ולא ימשיך הלאה מעבר למה שצריך
                {
                    NumToCount++;
                    WordFoundInGame = 0;
                    btnWord.Text = "";
                    btnTrans.Text = "";
                    btnTrans2.Text = "";
                    btnTrans3.Text = "";
                    btnTrans4.Text = "";
                    btnAgain_Click(null, null);
                }
            }
            else
                label3.Text = "not correct";
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text;
            string lang = "english";
            int unit = 11;
            string translation = txtTrans.Text;
            int points = 0;

            // SQL query to insert a new word into the AllWords table
            string query = "INSERT INTO AllWords (Word, Lang, Unit, Translation, Points) VALUES (@Word, @Lang, @Unit, @Translation, @Points)";

            // Create a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString3))
            {
                // Create a new SqlCommand with the SQL query and SqlConnection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Word", word);
                    command.Parameters.AddWithValue("@Lang", lang);
                    command.Parameters.AddWithValue("@Unit", unit);
                    command.Parameters.AddWithValue("@Translation", translation);
                    command.Parameters.AddWithValue("@Points", points);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the SQL command to insert the new word
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the insertion was successful
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("New word inserted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add word", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Console.WriteLine("Failed to insert new word.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Failed to add word", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    finally
                    {
                        connection.Close();
                        this.Controls.Clear();//לניקוי
                        InitializeComponent();
                        Form1_Load(e, e);
                    }
                }
            }
        }
    }
}
