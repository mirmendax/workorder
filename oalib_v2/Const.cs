namespace oalib
{

    public class Const
    {
        public const string DATA_FILE = "data.db";
        public const string DATE_FORMAT = "dd.MM.yy";
        public const string FILE_LOG = "log_v2.log";
        public const string ABOUT_FORMAT = "WorkOrder {0} Programming [MIR] Mendax (c) 2006-2019// СРЗАиМ уч. ТАиВ";

        public const string SQL_CONNECTION = "Data Source = "+DATA_FILE+"; Version = 3";

        public const bool   IS_DEBUG = false;

        public const string DOP_INSTR = "Другие указания по характеру и месту работы: ";

        public const int    LIMIT_ORDER_ARHIV = 30;

        //Error
        public const string ERR_NO_TEAM = "Добавьте одного члена бригады.";
        public const string ERR_NO_GIVE_OR_FORE = "Нет отдающего распоряжения или производителя работ.";
        public const string ERR_DUPLECATE_EMP = "Такой работник уже есть в бригаде!";
        public const string ERR_BR_OUT_DIAPOSON = "В бригаде достаточно работников!";
        public const string ERR_NO_ESTR_OR_INSTR = "Нет задания или краткого инструктажа.";
    }


}