﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunP
{
    public interface ISQLWork                      //описывает интерфейс модели работы с запросами
    {
        List<string> GetRequestNames();                             //возвращает список имен запросов
        List<ITableLine> GetDataFromBase(string requestName, int startIndex, int endIndex, List<Pair> paramPairs);        //реализует сложный запрос request с параметрами paramPairs и возвращает строки от beginLineNum до endLineNum включительно
        ITableLine GetDataLine(int index);                          //возвращает строку номер index из результатов последнего запроса
        void AddReqToSheet(string name, ISQLRequest request);       //добавляет реализацию сложного запроса в список
        void DelReqFromSheet(string name);                          //удаляет реализацию сложного запроса из списка
    }
}