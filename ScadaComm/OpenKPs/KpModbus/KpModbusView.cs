﻿/*
 * Copyright 2015 Mikhail Shiryaev
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : KpModbus
 * Summary  : Device library user interface
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2012
 * Modified : 2015
 */

using Scada.Comm.Devices.KpModbus;

namespace Scada.Comm.Devices
{
    /// <summary>
    /// Device library user interface
    /// <para>Пользовательский интерфейс библиотеки КП</para>
    /// </summary>
    public class KpModbusView : KPView
    {
        /// <summary>
        /// Конструктор для общей настройки библиотеки КП
        /// </summary>
        public KpModbusView()
            : this(0)
        {
        }

        /// <summary>
        /// Конструктор для настройки конкретного КП
        /// </summary>
        public KpModbusView(int number)
            : base(number)
        {
            CanShowProps = true;
        }


        /// <summary>
        /// Описание библиотеки КП
        /// </summary>
        public override string KPDescr
        {
            get
            {
                return Localization.UseRussian ? 
                    "Взаимодействие с контроллерами по протоколу Modbus.\n\n" +
                    "Пользовательский параметр линии связи:\n" +
                    "TransMode - режим передачи данных (RTU, ASCII, TCP).\n\n" + 
                    "Параметр командной строки:\n" +
                    "имя файла шаблона.\n\n" +
                    "Команды ТУ:\n" +
                    "определяются шаблоном (стандартные или бинарные)." :

                    "Interacting with controllers via Modbus protocol.\n\n" +
                    "Custom communication line parameter:\n" +
                    "TransMode - data transmission mode (RTU, ASCII, TCP).\n\n" +
                    "Command line parameter:\n" +
                    "template file name.\n\n" +
                    "Commands:\n" +
                    "defined by template (standard or binary).";
            }
        }

        /// <summary>
        /// Отобразить свойства КП
        /// </summary>
        public override void ShowProps()
        {
            // загрузка словарей
            string errMsg;
            if (!Localization.UseRussian)
            {
                if (Localization.LoadDictionaries(AppDirs.LangDir, "KpModbus", out errMsg))
                    KpPhrases.Init();
                else
                    ScadaUtils.ShowError(errMsg);
            }

            if (Number > 0)
                // отображение свойств КП
                FrmDevProps.ShowDialog(Number, KPProps, AppDirs);
            else
                // отображение редактора шаблонов устройств
                FrmDevTemplate.ShowDialog(AppDirs);
        }
    }
}
