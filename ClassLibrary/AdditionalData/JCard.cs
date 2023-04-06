/////////////////////////////////////////////////////////////////////////////////////
//  File: JCard.cs                                                  22 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text;
using System.Text.Json;

namespace AdditionalData
{
    /// <summary>
    /// Static class for handling JCards. A JCard is a VCard formatted as a JSON object.
    /// RFC 6350 specifies the VCard format. RFC 7095 specifies the JCard JSON format.
    /// </summary>
    public static class JCard
    {
        /// <summary>
        /// Converts a JCard contained in a string into a vcardType.
        /// </summary>
        /// <param name="strJcard">Input string containing a JCard JSON object.</param>
        /// <returns>Returns a vcardType if successful or null if an error occurred.</returns>
        /// <exception cref="JsonException">Thrown if an error occurred during de-serialization.</exception>
        public static vcardType JCardStringToVCardType(string strJcard)
        {
            vcardType vcard = null;
            if (string.IsNullOrEmpty(strJcard) == true)
                return null;

            object[] ObjArray;
            try
            {
                ObjArray = JsonSerializer.Deserialize<object[]>(strJcard);
            }
            catch (JsonException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            if (ObjArray == null || ObjArray.Length < 2 || ObjArray[0].GetType() != typeof(JsonElement) ||
                ObjArray[1].GetType() != typeof(JsonElement))
                throw new ArgumentException("Unable to parse the input JCard string");

            JsonElement Je0 = (JsonElement)ObjArray[0];
            if (Je0.ValueKind != JsonValueKind.String || Je0.ToString() != "vcard")
                throw new ArgumentException("Unexpected type for the vcard property name");

            JsonElement Je1 = (JsonElement)ObjArray[1];
            if (Je1.ValueKind != JsonValueKind.Array)
                throw new ArgumentException("The vcard property is not an array");

            vcard = new vcardType();

            foreach (JsonElement Je2 in Je1.EnumerateArray())
            {
                if (Je2.ValueKind != JsonValueKind.Array || Je2.GetArrayLength() < 4)
                    continue;   // Ignore any invalid properties

                JsonElement ParamsJe = Je2[1];
                if (ParamsJe.ValueKind == JsonValueKind.Object)
                {   // Check if a group parameter is present. See Section 3.3.1.2 of RFC 7095.
                    JsonElement GroupJe;
                    if (ParamsJe.TryGetProperty("group", out GroupJe) == true)
                        ParseGroupElements(vcard, Je2, GroupJe.ToString());
                    else
                        ParseVcardElements(vcard, Je2);
                }
                else
                    continue;   // Skip this array element because it is not valid

            } // end foreach

            return vcard;
        }

        /// <summary>
        /// Processes a property array and adds the property to a group object. See Section 3.3.1.2 of
        /// RFC 7095 for a description of how property groups are handled for the JCard format. A 
        /// property group can contain the same properties as the parent vcardType object.
        /// </summary>
        /// <param name="vcard">The vcardType that may or may not contain the property group</param>
        /// <param name="Je">Contains a JSON array of the properties</param>
        /// <param name="strGroupName">The name of the property group.</param>
        private static void ParseGroupElements(vcardType vcard, JsonElement Je, string strGroupName)
        {
            group Grp = null;
            if (vcard.group == null || vcard.group.Length == 0)
            {
                Grp = new group();
                Grp.name = strGroupName;
                vcard.group = (group[])vcardType.AddObjToObjArray(vcard.group, Grp, typeof(group));
            }
            else
            {   // Search for and existing group by group.name
                foreach (group grp in vcard.group)
                {
                    if (grp.name == strGroupName)
                    {
                        Grp = grp;
                        break;
                    }
                }

                if (Grp == null)
                {   // Not found so create a new group
                    Grp = new group();
                    Grp.name = strGroupName;
                    vcard.group = (group[])vcardType.AddObjToObjArray(vcard.group, Grp, typeof(group));
                }
            }

            string strPropName = Je[0].ToString();
            switch (strPropName)
            {
                case "adr":
                    Parse_adr(Grp, Je);
                    break;
                case "anniversary":
                    Parse_anniversary(Grp, Je);
                    break;
                case "bday":
                    Parse_bday(Grp, Je);
                    break;
                case "caladruri":
                    Parse_caladruri(Grp, Je);
                    break;
                case "caluri":
                    Parse_caluri(Grp, Je);
                    break;
                case "categories":
                    Parse_categories(Grp, Je);
                    break;
                case "clientpidmap":
                    Parse_clientpidmap(Grp, Je);
                    break;
                case "email":
                    Parse_email(Grp, Je);
                    break;
                case "fburl":
                    Parse_fburl(Grp, Je);
                    break;
                case "fn":
                    Parse_fn(Grp, Je);
                    break;
                case "geo":
                    Parse_geo(Grp, Je);
                    break;
                case "impp":
                    Parse_impp(Grp, Je);
                    break;
                case "key":
                    Parse_key(Grp, Je);
                    break;
                case "kind":
                    Parse_kind(Grp, Je);
                    break;
                case "lang":
                    Parse_lang(Grp, Je);
                    break;
                case "logo":
                    Parse_logo(Grp, Je);
                    break;
                case "member":
                    Parse_member(Grp, Je);
                    break;
                case "n":
                    Parse_n(Grp, Je);
                    break;
                case "nickname":
                    Parse_nickname(Grp, Je);
                    break;
                case "note":
                    Parse_note(Grp, Je);
                    break;
                case "org":
                    Parse_org(Grp, Je);
                    break;
                case "photo":
                    Parse_photo(Grp, Je);
                    break;
                case "prodid":
                    Parse_prodid(Grp, Je);
                    break;
                case "related":
                    Parse_related(Grp, Je);
                    break;
                case "rev":
                    Parse_rev(Grp, Je);
                    break;
                case "role":
                    Parse_role(Grp, Je);
                    break;
                case "gender":
                    Parse_gender(Grp, Je);
                    break;
                case "sound":
                    Parse_sound(Grp, Je);
                    break;
                case "source":
                    Parse_source(Grp, Je);
                    break;
                case "tel":
                    Parse_tel(Grp, Je);
                    break;
                case "title":
                    Parse_title(Grp, Je);
                    break;
                case "tz":
                    Parse_tz(Grp, Je);
                    break;
                case "uid":
                    Parse_uid(Grp, Je);
                    break;
                case "url":
                    Parse_url(Grp, Je);
                    break;
            } // end switch strPropName
        }

        /// <summary>
        /// Parses the properties of the vcard root element.
        /// </summary>
        /// <param name="vcard"></param>
        /// <param name="Je"></param>
        private static void ParseVcardElements(vcardType vcard, JsonElement Je)
        {
            string strPropName = Je[0].ToString();
            switch (strPropName)
            {
                case "adr":
                    Parse_adr(vcard, Je);
                    break;
                case "anniversary":
                    Parse_anniversary(vcard, Je);
                    break;
                case "bday":
                    Parse_bday(vcard, Je);
                    break;
                case "caladruri":
                    Parse_caladruri(vcard, Je);
                    break;
                case "caluri":
                    Parse_caluri(vcard, Je);
                    break;
                case "categories":
                    Parse_categories(vcard, Je);
                    break;
                case "clientpidmap":
                    Parse_clientpidmap(vcard, Je);
                    break;
                case "email":
                    Parse_email(vcard, Je);
                    break;
                case "fburl":
                    Parse_fburl(vcard, Je);
                    break;
                case "fn":
                    Parse_fn(vcard, Je);
                    break;
                case "geo":
                    Parse_geo(vcard, Je);
                    break;
                case "impp":
                    Parse_impp(vcard, Je);
                    break;
                case "key":
                    Parse_key(vcard, Je);
                    break;
                case "kind":
                    Parse_kind(vcard, Je);
                    break;
                case "lang":
                    Parse_lang(vcard, Je);
                    break;
                case "logo":
                    Parse_logo(vcard, Je);
                    break;
                case "member":
                    Parse_member(vcard, Je);
                    break;
                case "n":
                    Parse_n(vcard, Je);
                    break;
                case "nickname":
                    Parse_nickname(vcard, Je);
                    break;
                case "note":
                    Parse_note(vcard, Je);
                    break;
                case "org":
                    Parse_org(vcard, Je);
                    break;
                case "photo":
                    Parse_photo(vcard, Je);
                    break;
                case "prodid":
                    Parse_prodid(vcard, Je);
                    break;
                case "related":
                    Parse_related(vcard, Je);
                    break;
                case "rev":
                    Parse_rev(vcard, Je);
                    break;
                case "role":
                    Parse_role(vcard, Je);
                    break;
                case "gender":
                    Parse_gender(vcard, Je);
                    break;
                case "sound":
                    Parse_sound(vcard, Je);
                    break;
                case "source":
                    Parse_source(vcard, Je);
                    break;
                case "tel":
                    Parse_tel(vcard, Je);
                    break;
                case "title":
                    Parse_title(vcard, Je);
                    break;
                case "tz":
                    Parse_tz(vcard, Je);
                    break;
                case "uid":
                    Parse_uid(vcard, Je);
                    break;
                case "url":
                    Parse_url(vcard, Je);
                    break;
            } // end switch strPropName
        }

        private static adr Build_adr(JsonElement Je)
        {
            adr Adr = new adr();
            JsonElement AdrJe = Je[3];
            if (AdrJe.GetArrayLength() < 7)
                return null;

            vcardType.AddStringItem(ref Adr.pobox, AdrJe[0].ToString());    // P.O. box    
            vcardType.AddStringItem(ref Adr.ext, AdrJe[1].ToString());      // Extended address (i.e., suite)
            vcardType.AddStringItem(ref Adr.street, AdrJe[2].ToString());   // Street address
            vcardType.AddStringItem(ref Adr.locality, AdrJe[3].ToString()); // Locality or city
            vcardType.AddStringItem(ref Adr.region, AdrJe[4].ToString());   // Region or state
            vcardType.AddStringItem(ref Adr.code, AdrJe[5].ToString());     // Postal or zip code
            vcardType.AddStringItem(ref Adr.country, AdrJe[6].ToString());  // Country

            JsonElement ParamJe = Je[1];
            if (ParamJe.ValueKind == JsonValueKind.Object)
            {
                adrParameters AdrParam = new adrParameters();
                AdrParam.type = GetTypeText(ParamJe);

                JsonElement JePrefProp;
                if (ParamJe.TryGetProperty("pref", out JePrefProp) == true)
                {
                    if (JePrefProp.ValueKind == JsonValueKind.String)
                    {
                        AdrParam.pref = new pref();
                        AdrParam.pref.integer = JePrefProp.ToString();
                    }
                }

                JsonElement LabelJe;
                if (ParamJe.TryGetProperty("label", out LabelJe) == true)
                {
                    AdrParam.label = new label();
                    AdrParam.label.text = LabelJe.ToString();
                }

                Adr.parameters = AdrParam;
            }

            return Adr;
        }

        private static void Parse_adr(vcardType vcard, JsonElement Je)
        {
            adr Adr = Build_adr(Je);
            if (Adr != null)
                vcard.adr = (adr[])vcardType.AddObjToObjArray(vcard.adr, Adr, typeof(adr));
        }

        private static void Parse_adr(group Grp, JsonElement Je)
        {
            adr Adr = Build_adr(Je);
            if (Adr != null)
                Grp.adr = (adr[])vcardType.AddObjToObjArray(Grp.adr, Adr, typeof(adr));
        }

        private static anniversary Build_anniversary(JsonElement Je)
        {
            anniversary An = new anniversary();
            An.Item = Je[3].ToString();
            string strElName = Je[2].ToString();
            // Note: cannot use ParseEnum here because of the exception case of "dateandortime"
            // which does not match the enum value of valuedateandortime.
            switch (strElName)
            {
                case "date":
                    An.ItemElementName = AnniversaryItemChoiceEnum.date;
                    break;
                case "datetime":
                    An.ItemElementName = AnniversaryItemChoiceEnum.datetime;
                    break;
                case "text":
                    An.ItemElementName = AnniversaryItemChoiceEnum.text;
                    break;
                case "date-and-or-time":
                    An.ItemElementName = AnniversaryItemChoiceEnum.valuedateandortime;
                    break;
                default:
                    An.ItemElementName = AnniversaryItemChoiceEnum.text;
                    break;
            }

            //An.ItemElementName = (AnniversaryItemChoiceEnum)ParseEnum(typeof(AnniversaryItemChoiceEnum), strElName,
            //    AnniversaryItemChoiceEnum.text.ToString());

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                An.parameters = new anniversaryParameters();
                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    An.parameters.altid = new altid();
                    An.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement CalScaleJe;
                if (ParamsJe.TryGetProperty("calscale", out CalScaleJe) == true)
                {
                    An.parameters.calscale = new calscale();
                    // Only one enum value is defined
                    An.parameters.calscale.text = calscaleText.gregorian;
                }
            }

            return An;
        }

        private static void Parse_anniversary(vcardType vcard, JsonElement Je)
        {
            vcard.anniversary = Build_anniversary(Je);
        }

        private static void Parse_anniversary(group Grp, JsonElement Je)
        {
            Grp.anniversary = Build_anniversary(Je);
        }

        private static bday Build_bday(JsonElement Je)
        {
            bday Bday = new bday();
            Bday.Item = Je[3].ToString();
            string strElName = Je[2].ToString();

            // Don't use ParseEnum() here because date-and-or-time does not match an enum value
            switch (strElName)
            {
                case "date":
                    Bday.ItemElementName = BdayItemChoiceEnum.date;
                    break;
                case "time":
                    Bday.ItemElementName = BdayItemChoiceEnum.time;
                    break;
                case "date-time":
                    Bday.ItemElementName = BdayItemChoiceEnum.datetime;
                    break;
                case "text":
                    Bday.ItemElementName = BdayItemChoiceEnum.text;
                    break;
                case "date-and-or-time":
                    Bday.ItemElementName = BdayItemChoiceEnum.valuedateandortime;
                    break;
                default:
                    Bday.ItemElementName = BdayItemChoiceEnum.text;
                    break;
            } // end switch

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Bday.parameters = new bdayParameters();
                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Bday.parameters.altid = new altid();
                    Bday.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement CalScaleJe;
                if (ParamsJe.TryGetProperty("calscale", out CalScaleJe) == true)
                {
                    Bday.parameters.calscale = new calscale();
                    // Only one enum value is defined
                    Bday.parameters.calscale.text = calscaleText.gregorian;
                }
            }

            return Bday;
        }

        private static void Parse_bday(vcardType vcard, JsonElement Je)
        {
            vcard.bday = Build_bday(Je);
        }

        private static void Parse_bday(group Grp, JsonElement Je)
        {
            Grp.bday = Build_bday(Je);
        }

        private static caladruri Build_caladruri(JsonElement Je)
        {
            caladruri CalAdrUri = new caladruri();
            CalAdrUri.uri = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                CalAdrUri.parameters = new caladruriParameters();
                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref CalAdrUri.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    CalAdrUri.parameters.pref = new pref();
                    CalAdrUri.parameters.pref.integer = PrefJe.ToString();
                }

                CalAdrUri.parameters.type = GetTypeText(ParamsJe);

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    CalAdrUri.parameters.mediatype = new mediatype();
                    CalAdrUri.parameters.mediatype.text = MediaJe.ToString();
                }

                JsonElement Altidje;
                if (ParamsJe.TryGetProperty("altid", out Altidje) == true)
                {
                    CalAdrUri.parameters.altid = new altid();
                    CalAdrUri.parameters.altid.text = Altidje.ToString();
                }
            }

            return CalAdrUri;
        }

        private static void Parse_caladruri(vcardType vcard, JsonElement Je)
        {
            caladruri Ca = Build_caladruri(Je);
            if (Ca != null)
                vcard.caladruri = (caladruri[])vcardType.AddObjToObjArray(vcard.caladruri, Ca,
                    typeof(CallerInfo));
        }

        private static void Parse_caladruri(group Grp, JsonElement Je)
        {
            caladruri Ca = Build_caladruri(Je);
            if (Ca != null)
                Grp.caladruri = (caladruri[])vcardType.AddObjToObjArray(Grp.caladruri, Ca,
                    typeof(caladruri));
        }

        private static caluri Build_caluri(JsonElement Je)
        {
            caluri Caluri = new caluri();
            Caluri.uri = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Caluri.parameters = new caluriParameters();
                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Caluri.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Caluri.parameters.pref = new pref();
                    Caluri.parameters.pref.integer = PrefJe.ToString();
                }

                Caluri.parameters.type = GetTypeText(ParamsJe);

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Caluri.parameters.mediatype = new mediatype();
                    Caluri.parameters.mediatype.text = MediaJe.ToString();
                }

                JsonElement Altidje;
                if (ParamsJe.TryGetProperty("altid", out Altidje) == true)
                {
                    Caluri.parameters.altid = new altid();
                    Caluri.parameters.altid.text = Altidje.ToString();
                }
            }

            return Caluri;
        }

        private static void Parse_caluri(vcardType vcard, JsonElement Je)
        {
            caluri Cu = Build_caluri(Je);
            if (Cu != null)
                vcard.caluri = (caluri[])vcardType.AddObjToObjArray(vcard.caluri, Cu, typeof(caluri));
        }

        private static void Parse_caluri(group Grp, JsonElement Je)
        {
            caluri Cu = Build_caluri(Je);
            if (Cu != null)
                Grp.caluri = (caluri[])vcardType.AddObjToObjArray(Grp.caluri, Cu, typeof(caluri));
        }

        private static categories Build_categories(JsonElement Je)
        {
            categories Cat = new categories();

            // Calculate the number of strings in the text list, which starts at index = 3.
            int NumEls = Je.GetArrayLength() - 3;
            if (NumEls <= 0)
                return null;    // Error condition

            Cat.text = new string[NumEls];
            for (int i = 0; i < NumEls; i++)
                Cat.text[i] = Je[3 + i].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Cat.parameters = new categoriesParameters();
                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Cat.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Cat.parameters.pref = new pref();
                    Cat.parameters.pref.integer = PrefJe.ToString();
                }

                Cat.parameters.type = GetTypeText(ParamsJe);

                JsonElement Altidje;
                if (ParamsJe.TryGetProperty("altid", out Altidje) == true)
                {
                    Cat.parameters.altid = new altid();
                    Cat.parameters.altid.text = Altidje.ToString();
                }
            }

            return Cat;
        }

        private static void Parse_categories(vcardType vcard, JsonElement Je)
        {
            categories Cat = Build_categories(Je);
            if (Cat != null)
                vcard.categories = (categories[])vcardType.AddObjToObjArray(vcard.categories, Cat,
                    typeof(categories));
        }

        private static void Parse_categories(group Grp, JsonElement Je)
        {
            categories Cat = Build_categories(Je);
            if (Cat != null)
                Grp.categories = (categories[])vcardType.AddObjToObjArray(Grp.categories, Cat,
                    typeof(categories));
        }

        private static clientpidmap Build_clientpidmap(JsonElement Je)
        {
            clientpidmap Cpm = new clientpidmap();

            Cpm.sourceid = Je[3].ToString();
            if (Je.GetArrayLength() > 4)
                Cpm.uri = Je[4].ToString();

            return Cpm;
        }

        private static void Parse_clientpidmap(vcardType vcard, JsonElement Je)
        {
            clientpidmap Cpm = Build_clientpidmap(Je);
            if (Cpm != null)
                vcard.clientpidmap = (clientpidmap[])vcardType.AddObjToObjArray(vcard.clientpidmap,
                    Cpm, typeof(clientpidmap));
        }

        private static void Parse_clientpidmap(group Grp, JsonElement Je)
        {
            clientpidmap Cpm = Build_clientpidmap(Je);
            if (Cpm != null)
                Grp.clientpidmap = (clientpidmap[])vcardType.AddObjToObjArray(Grp.clientpidmap,
                    Cpm, typeof(clientpidmap));
        }

        private static tel Build_tel(JsonElement Je)
        {
            tel Tel = new tel();
            JsonElement TelTypeJe = Je[2];
            if (TelTypeJe.ValueKind != JsonValueKind.String || Je[1].ValueKind != JsonValueKind.Object)
                return null;    // Error

            string strType = TelTypeJe.ToString();
            if (strType == "uri")
                Tel.ItemElementName = TelItemChoiceEnum.uri;
            else if (strType == "text")
                Tel.ItemElementName = TelItemChoiceEnum.text;

            Tel.Item = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Tel.parameters = new telParameters();

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true && PrefJe.ValueKind ==
                    JsonValueKind.String)
                {
                    Tel.parameters.pref = new pref();
                    Tel.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement TypeJe;
                if (ParamsJe.TryGetProperty("type", out TypeJe) == true)
                    AddStringElemments(ref Tel.parameters.type, TypeJe);
            }

            return Tel;
        }

        private static void Parse_tel(vcardType vcard, JsonElement Je)
        {
            tel Tel = Build_tel(Je);
            if (Tel != null)
                vcard.tel = (tel[])vcardType.AddObjToObjArray(vcard.tel, Tel, typeof(tel));
        }

        private static void Parse_tel(group Grp, JsonElement Je)
        {
            tel Tel = Build_tel(Je);
            if (Tel != null)
                Grp.tel = (tel[])vcardType.AddObjToObjArray(Grp.tel, Tel, typeof(tel));
        }

        private static n Build_n(JsonElement Je)
        {
            n N = new n();
            JsonElement NamesJe = Je[3];
            if (NamesJe.ValueKind != JsonValueKind.Array || NamesJe.GetArrayLength() < 5)
                return null;    // Error

            // Surname
            AddStringElemments(ref N.surname, NamesJe[0]);

            // Given names
            AddStringElemments(ref N.given, NamesJe[1]);

            // Additional names (middle, etc)
            AddStringElemments(ref N.additional, NamesJe[2]);

            // Name prefixes
            AddStringElemments(ref N.prefix, NamesJe[3]);

            // Name suffixes
            AddStringElemments(ref N.suffix, NamesJe[4]);

            // Handle the name parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                N.parameters = new nParameters();
                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    N.parameters.language = new language();
                    N.parameters.language.languagetag = LangJe.ToString();
                }

                JsonElement SortasJe;
                if (ParamsJe.TryGetProperty("sortas", out SortasJe) == true)
                    AddStringElemments(ref N.parameters.sortas, SortasJe);

                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    N.parameters.altid = new altid();
                    N.parameters.altid.text = AltId.ToString();
                }
            }

            return N;
        }

        private static void AddStringElemments(ref string[] OutArray, JsonElement Je)
        {
            OutArray = null;
            if (Je.ValueKind == JsonValueKind.String)
            {
                OutArray = new string[1];
                OutArray[0] = Je.ToString();
            }
            else if (Je.ValueKind == JsonValueKind.Array)
            {
                OutArray = new string[Je.GetArrayLength()];
                for (int i = 0; i < Je.GetArrayLength(); i++)
                    OutArray[i] = Je[i].ToString();
            }
        }

        private static void Parse_n(vcardType vcard, JsonElement Je)
        {
            n N = Build_n(Je);
            if (N != null)
                vcard.n = N;
        }

        private static void Parse_n(group Grp, JsonElement Je)
        {
            n N = Build_n(Je);
            if (N != null)
                Grp.n = N;
        }

        private static nickname Build_nickname(JsonElement Je)
        {
            nickname Nn = new nickname();
            // Calculate the number of strings in the text list, which starts at index = 3.
            int NumEls = Je.GetArrayLength() - 3;
            if (NumEls <= 0)
                return null;    // Error condition

            Nn.text = new string[NumEls];
            for (int i = 0; i < NumEls; i++)
                Nn.text[i] = Je[3 + i].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Nn.parameters = new nicknameParameters();
                Nn.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Nn.parameters.altid = new altid();
                    Nn.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Nn.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Nn.parameters.pref = new pref();
                    Nn.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Nn.parameters.language = new language();
                    Nn.parameters.language.languagetag = LangJe.ToString();
                }
            }

            return Nn;
        }

        private static void Parse_nickname(vcardType vcard, JsonElement Je)
        {
            nickname Nn = Build_nickname(Je);
            if (Nn != null)
                vcard.nickname = (nickname[])vcardType.AddObjToObjArray(vcard.nickname, Nn,
                    typeof(nickname));
        }

        private static void Parse_nickname(group Grp, JsonElement Je)
        {
            nickname Nn = Build_nickname(Je);
            if (Nn != null)
                Grp.nickname = (nickname[])vcardType.AddObjToObjArray(Grp.nickname, Nn,
                    typeof(nickname));
        }

        private static note Build_note(JsonElement Je)
        {
            note Note = new note();
            Note.text = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Note.parameters = new noteParameters();
                Note.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Note.parameters.altid = new altid();
                    Note.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Note.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Note.parameters.pref = new pref();
                    Note.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Note.parameters.language = new language();
                    Note.parameters.language.languagetag = LangJe.ToString();
                }
            }

            return Note;
        }

        private static void Parse_note(vcardType vcard, JsonElement Je)
        {
            note Note = Build_note(Je);
            if (Note != null)
                vcard.note = (note[])vcardType.AddObjToObjArray(vcard.note, Note, typeof(note));
        }

        private static void Parse_note(group Grp, JsonElement Je)
        {
            note Note = Build_note(Je);
            if (Note != null)
                Grp.note = (note[])vcardType.AddObjToObjArray(Grp.note, Note, typeof(note));
        }

        private static org Build_org(JsonElement Je)
        {
            org Org = new org();
            // Calculate the number of strings in the text list, which starts at index = 3.
            int NumEls = Je.GetArrayLength() - 3;
            if (NumEls <= 0)
                return null;    // Error condition

            Org.text = new string[NumEls];
            for (int i = 0; i < NumEls; i++)
                Org.text[i] = Je[3 + i].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Org.parameters = new orgParameters();
                Org.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Org.parameters.altid = new altid();
                    Org.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Org.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Org.parameters.pref = new pref();
                    Org.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Org.parameters.language = new language();
                    Org.parameters.language.languagetag = LangJe.ToString();
                }

                JsonElement SortasJe;
                if (ParamsJe.TryGetProperty("sortas", out SortasJe) == true)
                    AddStringElemments(ref Org.parameters.sortas, SortasJe);
            }

            return Org;
        }

        private static void Parse_org(vcardType vcard, JsonElement Je)
        {
            org Org = Build_org(Je);
            if (Org != null)
                vcard.org = (org[])vcardType.AddObjToObjArray(vcard.org, Org, typeof(org));
        }

        private static void Parse_org(group Grp, JsonElement Je)
        {
            org Org = Build_org(Je);
            if (Org != null)
                Grp.org = (org[])vcardType.AddObjToObjArray(Grp.org, Org, typeof(org));
        }

        private static photo Build_photo(JsonElement Je)
        {
            photo Photo = new photo();
            Photo.uri = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Photo.parameters = new photoParameters();
                Photo.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Photo.parameters.altid = new altid();
                    Photo.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Photo.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Photo.parameters.pref = new pref();
                    Photo.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Photo.parameters.mediatype = new mediatype();
                    Photo.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Photo;
        }

        private static void Parse_photo(vcardType vcard, JsonElement Je)
        {
            photo Photo = Build_photo(Je);
            if (Photo != null)
                vcard.photo = (photo[])vcardType.AddObjToObjArray(vcard.photo, Photo, typeof(photo));
        }

        private static void Parse_photo(group Grp, JsonElement Je)
        {
            photo Photo = Build_photo(Je);
            if (Photo != null)
                Grp.photo = (photo[])vcardType.AddObjToObjArray(Grp.photo, Photo, typeof(photo));
        }

        private static prodid Build_prodid(JsonElement Je)
        {
            prodid Prodid = new prodid();
            Prodid.text = Je[3].ToString();
            // There are no parameters for prodid.
            return Prodid;
        }

        private static void Parse_prodid(vcardType vcard, JsonElement Je)
        {
            vcard.prodid = Build_prodid(Je);
        }

        private static void Parse_prodid(group Grp, JsonElement Je)
        {
            Grp.prodid = Build_prodid(Je);
        }

        private static related Build_related(JsonElement Je)
        {
            related Rel = new related();
            Rel.Item = Je[3].ToString();

            string str = Je[2].ToString();
            Rel.ItemElementName = (RelatedParametersItemChoiceEnum)ParseEnum(typeof(RelatedParametersItemChoiceEnum), str,
                RelatedParametersItemChoiceEnum.text.ToString());

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Rel.parameters = new relatedParameters();
                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Rel.parameters.altid = new altid();
                    Rel.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Rel.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Rel.parameters.pref = new pref();
                    Rel.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement TypeJe;
                if (ParamsJe.TryGetProperty("type", out TypeJe) == true)
                {
                    if (TypeJe.ValueKind == JsonValueKind.String)
                    {
                        Rel.parameters.type = new relatedParametersText[1];
                        Rel.parameters.type[0] = (relatedParametersText)ParseEnum(
                            typeof(relatedParametersText), TypeJe.ToString(), relatedParametersText.
                            work.ToString());
                    }
                    else if (TypeJe.ValueKind == JsonValueKind.Array)
                    {
                        int Count = TypeJe.GetArrayLength();
                        Rel.parameters.type = new relatedParametersText[Count];
                        for (int i = 0; i < Count; i++)
                        {
                            if (TypeJe[i].ValueKind == JsonValueKind.String)
                                Rel.parameters.type[i] = (relatedParametersText)ParseEnum(
                                    typeof(relatedParametersText), TypeJe[i].ToString(),
                                    relatedParametersText.work.ToString());
                        }
                    }
                }
            }

            return Rel;
        }

        private static object ParseEnum(Type type, string str, string strDefault)
        {
            object RetVal = null;
            try
            {
                RetVal = Enum.Parse(type, str, true);
            }
            catch (ArgumentException)
            {   // Value not found, so try to use the default.
                RetVal = Enum.Parse(type, strDefault, true);
            }
            catch (Exception)
            {

            }
            return RetVal;
        }

        private static void Parse_related(vcardType vcard, JsonElement Je)
        {
            related Rel = Build_related(Je);
            if (Rel != null)
                vcard.related = (related[])vcardType.AddObjToObjArray(vcard.related, Rel, typeof(related));
        }

        private static void Parse_related(group Grp, JsonElement Je)
        {
            related Rel = Build_related(Je);
            if (Rel != null)
                Grp.related = (related[])vcardType.AddObjToObjArray(Grp.related, Rel, typeof(related));
        }

        private static valuetimestamp Build_rev(JsonElement Je)
        {
            valuetimestamp Rev = new valuetimestamp();
            Rev.timestamp = Je[3].ToString();
            return Rev;
        }

        private static void Parse_rev(vcardType vcard, JsonElement Je)
        {
            vcard.rev = Build_rev(Je);    
        }

        private static void Parse_rev(group Grp, JsonElement Je)
        {
            Grp.rev = Build_rev(Je);
        }

        private static role Build_role(JsonElement Je)
        {
            role Role = new role();
            Role.text = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Role.parameters = new roleParameters();
                Role.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Role.parameters.altid = new altid();
                    Role.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Role.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Role.parameters.pref = new pref();
                    Role.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Role.parameters.language = new language();
                    Role.parameters.language.languagetag = LangJe.ToString();
                }
            }

            return Role;
        }

        private static void Parse_role(vcardType vcard, JsonElement Je)
        {
            role Role = Build_role(Je);
            if (Role != null)
                vcard.role = (role[])vcardType.AddObjToObjArray(vcard.role, Role, typeof(role));
        }

        private static void Parse_role(group Grp, JsonElement Je)
        {
            role Role = Build_role(Je);
            if (Role != null)
                Grp.role = (role[])vcardType.AddObjToObjArray(Grp.role, Role, typeof(role));
        }

        private static fn Build_fn(JsonElement Je)
        {
            fn Fn = new fn();
            Fn.text = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Fn.parameters = new fnParameters();
                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Fn.parameters.language = new language();
                    Fn.parameters.language.languagetag = LangJe.ToString();
                }

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Fn.parameters.altid = new altid();
                    Fn.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Fn.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Fn.parameters.pref = new pref();
                    Fn.parameters.pref.integer = PrefJe.ToString();
                }
            }

            return Fn;
        }

        private static void Parse_fn(vcardType vcard, JsonElement Je)
        {
            fn Fn = Build_fn(Je);
            if (Fn != null)
                vcard.fn = (fn[])vcardType.AddObjToObjArray(vcard.fn, Fn, typeof(fn));
        }

        private static void Parse_fn(group Grp, JsonElement Je)
        {
            fn Fn = Build_fn(Je);
            if (Fn != null)
                Grp.fn = (fn[])vcardType.AddObjToObjArray(Grp.fn, Fn, typeof(fn));
        }

        private static email Build_email(JsonElement Je)
        {
            email Email = null;
            if (Je.ValueKind != JsonValueKind.Array || Je.GetArrayLength() < 4)
                return null;    // Error

            Email = new email();
            Email.text = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Email.parameters = new emailParameters();
                Email.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Email.parameters.altid = new altid();
                    Email.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Email.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Email.parameters.pref = new pref();
                    Email.parameters.pref.integer = PrefJe.ToString();
                }
            }

            return Email;
        }

        private static void Parse_email(vcardType vcard, JsonElement Je)
        {
            email Email = Build_email(Je);
            if (Email != null)
                vcard.email = (email[])vcardType.AddObjToObjArray(vcard.email, Email, typeof(email));
        }

        private static void Parse_email(group Grp, JsonElement Je)
        {
            email Email = Build_email(Je);
            if (Email != null)
                Grp.email = (email[])vcardType.AddObjToObjArray(Grp.email, Email, typeof(email));
        }

        private static fburl Build_fburl(JsonElement Je)
        {
            fburl Fburl = new fburl();
            Fburl.uri = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Fburl.parameters = new fburlParameters();
                Fburl.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltIdJe;
                if (ParamsJe.TryGetProperty("altid", out AltIdJe) == true)
                {
                    Fburl.parameters.altid = new altid();
                    Fburl.parameters.altid.text = AltIdJe.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Fburl.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Fburl.parameters.pref = new pref();
                    Fburl.parameters.pref.integer = PrefJe.ToString();
                }
            }

            return Fburl;
        }

        private static void Parse_fburl(vcardType vcard, JsonElement Je)
        {
            fburl Fburl = Build_fburl(Je);
            if (Fburl != null)
                vcard.fburl = (fburl[])vcardType.AddObjToObjArray(vcard.fburl, Fburl, typeof(fburl));
        }

        private static void Parse_fburl(group Grp, JsonElement Je)
        {
            fburl Fburl = Build_fburl(Je);
            if (Fburl != null)
                Grp.fburl = (fburl[])vcardType.AddObjToObjArray(Grp.fburl, Fburl, typeof(fburl));
        }

        private static vcardTypeGeo Build_geo(JsonElement Je)
        {
            vcardTypeGeo Geo = new vcardTypeGeo();

            if (Je[3].ValueKind == JsonValueKind.String)
                Geo.uri = Je[3].ToString();

            JsonElement GeoParams = Je[1];
            if (GeoParams.ValueKind == JsonValueKind.Object)
            {
                Geo.parameters = new vcardTypeGeoParameters();

                JsonElement AltId;
                if (GeoParams.TryGetProperty("altid", out AltId) == true)
                {
                    Geo.parameters.altid = new altid();
                    Geo.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (GeoParams.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Geo.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (GeoParams.TryGetProperty("pref", out PrefJe) == true)
                {
                    Geo.parameters.pref = new pref();
                    Geo.parameters.pref.integer = PrefJe.ToString();
                }

                Geo.parameters.type = GetTypeText(GeoParams);

                JsonElement MediaJe;
                if (GeoParams.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Geo.parameters.mediatype = new mediatype();
                    Geo.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Geo;
        }

        private static void Parse_geo(vcardType vcard, JsonElement Je)
        {
            vcardTypeGeo Geo = Build_geo(Je);
            if (Geo != null)
                vcard.geo = (vcardTypeGeo[])vcardType.AddObjToObjArray(vcard.geo, Geo,
                    typeof(vcardTypeGeo));
        }

        private static void Parse_geo(group Grp, JsonElement Je)
        {
            vcardTypeGeo Geo = Build_geo(Je);
            if (Geo != null)
                Grp.geo = (vcardTypeGeo[])vcardType.AddObjToObjArray(Grp.geo, Geo,
                    typeof(vcardTypeGeo));
        }


        private static impp Build_impp(JsonElement Je)
        {
            impp Impp = new impp();
            Impp.uri = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Impp.parameters = new imppParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Impp.parameters.altid = new altid();
                    Impp.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Impp.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Impp.parameters.pref = new pref();
                    Impp.parameters.pref.integer = PrefJe.ToString();
                }

                Impp.parameters.type = GetTypeText(ParamsJe);
            }

            return Impp;
        }

        private static void Parse_impp(vcardType vcard, JsonElement Je)
        {
            impp Impp = Build_impp(Je);
            if (Impp != null)
                vcard.impp = (impp[])vcardType.AddObjToObjArray(vcard.impp, Impp, typeof(impp));
        }

        private static void Parse_impp(group Grp, JsonElement Je)
        {
            impp Impp = Build_impp(Je);
            if (Impp != null)
                Grp.impp = (impp[])vcardType.AddObjToObjArray(Grp.impp, Impp, typeof(impp));
        }

        private static key Build_key(JsonElement Je)
        {
            key Key = new key();
            Key.Item = Je[3].ToString();
            string strItemName = Je[2].ToString();
            Key.ItemElementName = (KeyItemChoiceEnum)ParseEnum(typeof(KeyItemChoiceEnum), strItemName,
                KeyItemChoiceEnum.text.ToString());

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Key.parameters = new keyParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Key.parameters.altid = new altid();
                    Key.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Key.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Key.parameters.pref = new pref();
                    Key.parameters.pref.integer = PrefJe.ToString();
                }

                Key.parameters.type = GetTypeText(ParamsJe);
            }

            return Key;
        }

        private static void Parse_key(vcardType vcard, JsonElement Je)
        {
            key Key = Build_key(Je);
            if (Key != null)
                vcard.key = (key[])vcardType.AddObjToObjArray(vcard.key, Key, typeof(key));
        }

        private static void Parse_key(group Grp, JsonElement Je)
        {
            key Key = Build_key(Je);
            if (Key != null)
                Grp.key = (key[])vcardType.AddObjToObjArray(Grp.key, Key, typeof(key));
        }

        private static kind Build_kind(JsonElement Je)
        {
            kind Kind = new kind();
            Kind.text = Je[3].ToString();
            return Kind;
        }

        private static void Parse_kind(vcardType vcard, JsonElement Je)
        {
            vcard.kind = Build_kind(Je);
        }

        private static void Parse_kind(group Grp, JsonElement Je)
        {
            Grp.kind = Build_kind(Je);
        }

        private static lang Build_lang(JsonElement Je)
        {
            lang Lang = new lang();
            Lang.languagetag = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Lang.parameters = new langParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Lang.parameters.altid = new altid();
                    Lang.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Lang.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Lang.parameters.pref = new pref();
                    Lang.parameters.pref.integer = PrefJe.ToString();
                }

                Lang.parameters.type = GetTypeText(ParamsJe);
            }

            return Lang;
        }

        private static void Parse_lang(vcardType vcard, JsonElement Je)
        {
            lang Lang = Build_lang(Je);
            if (Lang != null)
                vcard.lang = (lang[])vcardType.AddObjToObjArray(vcard.lang, Lang, typeof(lang));
        }

        private static void Parse_lang(group Grp, JsonElement Je)
        {
            lang Lang = Build_lang(Je);
            if (Lang != null)
                Grp.lang = (lang[])vcardType.AddObjToObjArray(Grp.lang, Lang, typeof(lang));
        }

        private static logo Build_logo(JsonElement Je)
        {
            logo Logo = new logo();
            Logo.uri = Je[3].ToString();

            // Handle the parameters
            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Logo.parameters = new logoParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Logo.parameters.altid = new altid();
                    Logo.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Logo.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Logo.parameters.pref = new pref();
                    Logo.parameters.pref.integer = PrefJe.ToString();
                }

                Logo.parameters.type = GetTypeText(ParamsJe);

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Logo.parameters.language = new language();
                    Logo.parameters.language.languagetag = LangJe.ToString();
                }
            }

            return Logo;
        }

        private static void Parse_logo(vcardType vcard, JsonElement Je)
        {
            logo Logo = Build_logo(Je);
            if (Logo != null)
                vcard.logo = (logo[])vcardType.AddObjToObjArray(vcard.logo, Logo, typeof(logo));
        }

        private static void Parse_logo(group Grp, JsonElement Je)
        {
            logo Logo = Build_logo(Je);
            if (Logo != null)
                Grp.logo = (logo[])vcardType.AddObjToObjArray(Grp.logo, Logo, typeof(logo));
        }

        private static member Build_member(JsonElement Je)
        {
            member Mem = new member();
            Mem.uri = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Mem.parameters = new memberParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Mem.parameters.altid = new altid();
                    Mem.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Mem.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Mem.parameters.pref = new pref();
                    Mem.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Mem.parameters.mediatype = new mediatype();
                    Mem.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Mem;
        }

        private static void Parse_member(vcardType vcard, JsonElement Je)
        {
            member Mem = Build_member(Je);
            if (Mem != null)
                vcard.member = (member[])vcardType.AddObjToObjArray(vcard.member, Mem, typeof(member));
        }

        private static void Parse_member(group Grp, JsonElement Je)
        {
            member Mem = Build_member(Je);
            if (Mem != null)
                Grp.member = (member[])vcardType.AddObjToObjArray(Grp.member, Mem, typeof(member));
        }

        private static gender Build_gender(JsonElement Je)
        {
            gender Gender = new gender();

            string strSex = "U";
            if (Je[3].ValueKind == JsonValueKind.String)
                strSex = Je[3].ToString();
            else if (Je[3].ValueKind == JsonValueKind.Array && Je[3].GetArrayLength() > 2)
            {
                JsonElement SexJe = Je[3];
                strSex = SexJe[0].ToString();
                Gender.identity = SexJe[1].ToString();
            }
            else
                return null;    // Error

            Gender.sex = (sex)ParseEnum(typeof(sex), strSex, sex.U.ToString());

            // There are no parameters for gender

            return Gender;
        }

        private static void Parse_gender(vcardType vcard, JsonElement Je)
        {
            vcard.gender = Build_gender(Je);
        }

        private static void Parse_gender(group Grp, JsonElement Je)
        {
            Grp.gender = Build_gender(Je);
        }

        private static sound Build_sound(JsonElement Je)
        {
            sound Sound = new sound();
            Sound.uri = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Sound.parameters = new soundParameters();
                Sound.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Sound.parameters.altid = new altid();
                    Sound.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Sound.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Sound.parameters.pref = new pref();
                    Sound.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Sound.parameters.mediatype = new mediatype();
                    Sound.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Sound;
        }

        private static void Parse_sound(vcardType vcard, JsonElement Je)
        {
            sound Sound = Build_sound(Je);
            if (Sound != null)
                vcard.sound = (sound[])vcardType.AddObjToObjArray(vcard.sound, Sound, typeof(sound));
        }

        private static void Parse_sound(group Grp, JsonElement Je)
        {
            sound Sound = Build_sound(Je);
            if (Sound != null)
                Grp.sound = (sound[])vcardType.AddObjToObjArray(Grp.sound, Sound, typeof(sound));
        }

        private static source Build_source(JsonElement Je)
        {
            source Src = new source();
            Src.uri = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Src.parameters = new sourceParameters();
                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Src.parameters.altid = new altid();
                    Src.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Src.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Src.parameters.pref = new pref();
                    Src.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Src.parameters.mediatype = new mediatype();
                    Src.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Src;
        }

        private static void Parse_source(vcardType vcard, JsonElement Je)
        {
            source Src = Build_source(Je);
            if (Src != null)
                vcard.source = (source[])vcardType.AddObjToObjArray(vcard.source, Src, typeof(source));
        }

        private static void Parse_source(group Grp, JsonElement Je)
        {
            source Src = Build_source(Je);
            if (Src != null)
                Grp.source = (source[])vcardType.AddObjToObjArray(Grp.source, Src, typeof(source));
        }

        private static title Build_title(JsonElement Je)
        {
            title Title = new title();
            Title.text = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Title.parameters = new titleParameters();
                Title.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Title.parameters.altid = new altid();
                    Title.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Title.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Title.parameters.pref = new pref();
                    Title.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement LangJe;
                if (ParamsJe.TryGetProperty("language", out LangJe) == true)
                {
                    Title.parameters.language = new language();
                    Title.parameters.language.languagetag = LangJe.ToString();
                }
            }

            return Title;
        }

        private static void Parse_title(vcardType vcard, JsonElement Je)
        {
            title Title = Build_title(Je);
            if (Title != null)
                vcard.title = (title[])vcardType.AddObjToObjArray(vcard.title, Title, typeof(title));
        }

        private static void Parse_title(group Grp, JsonElement Je)
        {
            title Title = Build_title(Je);
            if (Title != null)
                Grp.title = (title[])vcardType.AddObjToObjArray(Grp.title, Title, typeof(title));
        }

        private static vcardTypeTZ Build_tz(JsonElement Je)
        {
            vcardTypeTZ Tz = new vcardTypeTZ();
            Tz.Item = Je[3].ToString();

            string strEn = Je[2].ToString().Replace("-", "");

            Tz.ItemElementName = (VcardTypeTzItemChoiceEnum)ParseEnum(typeof(VcardTypeTzItemChoiceEnum), strEn,
                VcardTypeTzItemChoiceEnum.text.ToString());

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Tz.parameters = new vcardTypeTZParameters();
                Tz.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Tz.parameters.altid = new altid();
                    Tz.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Tz.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Tz.parameters.pref = new pref();
                    Tz.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Tz.parameters.mediatype = new mediatype();
                    Tz.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Tz;
        }

        private static void Parse_tz(vcardType vcard, JsonElement Je)
        {
            vcardTypeTZ Tz = Build_tz(Je);
            if (Tz != null)
                vcard.tz = (vcardTypeTZ[])vcardType.AddObjToObjArray(vcard.tz, Tz, typeof(vcardTypeTZ));
        }

        private static void Parse_tz(group Grp, JsonElement Je)
        {
            vcardTypeTZ Tz = Build_tz(Je);
            if (Tz != null)
                Grp.tz = (vcardTypeTZ[])vcardType.AddObjToObjArray(Grp.tz, Tz, typeof(vcardTypeTZ));
        }

        private static uid Build_uid(JsonElement Je)
        {
            uid Uid = new uid();
            Uid.uri = Je[3].ToString();
            return Uid;
        }

        private static void Parse_uid(vcardType vcard, JsonElement Je)
        {
            vcard.uid = Build_uid(Je);
        }

        private static void Parse_uid(group Grp, JsonElement Je)
        {
            Grp.uid = Build_uid(Je);
        }

        private static typeText[] GetTypeText(JsonElement Je)
        {
            typeText[] TypeText = null;
            JsonElement TypeJe;
            if (Je.TryGetProperty("type", out TypeJe) == true)
            {
                string strType = TypeJe.ToString();
                // There are only two values for the typeText enum so the array can contain
                // only one element.
                TypeText = new typeText[1];
                if (strType == "home")
                    TypeText[0] = typeText.home;
                else if (strType == "work")
                    TypeText[0] = typeText.work;
                else
                    TypeText[0] = typeText.home;
            }

            return TypeText;
        }

        private static url Build_url(JsonElement Je)
        {
            url Url = new url();
            Url.uri = Je[3].ToString();

            JsonElement ParamsJe = Je[1];
            if (ParamsJe.ValueKind == JsonValueKind.Object)
            {
                Url.parameters = new urlParameters();
                Url.parameters.type = GetTypeText(ParamsJe);

                JsonElement AltId;
                if (ParamsJe.TryGetProperty("altid", out AltId) == true)
                {
                    Url.parameters.altid = new altid();
                    Url.parameters.altid.text = AltId.ToString();
                }

                JsonElement PidJe;
                if (ParamsJe.TryGetProperty("pid", out PidJe) == true)
                    AddStringElemments(ref Url.parameters.pid, PidJe);

                JsonElement PrefJe;
                if (ParamsJe.TryGetProperty("pref", out PrefJe) == true)
                {
                    Url.parameters.pref = new pref();
                    Url.parameters.pref.integer = PrefJe.ToString();
                }

                JsonElement MediaJe;
                if (ParamsJe.TryGetProperty("mediatype", out MediaJe) == true)
                {
                    Url.parameters.mediatype = new mediatype();
                    Url.parameters.mediatype.text = MediaJe.ToString();
                }
            }

            return Url;
        }

        private static void Parse_url(vcardType vcard, JsonElement Je)
        {
            url Url = Build_url(Je);
            if (Url != null)
                vcard.url = (url[])vcardType.AddObjToObjArray(vcard.url, Url, typeof(url));
        }

        private static void Parse_url(group Grp, JsonElement Je)
        {
            url Url = Build_url(Je);
            if (Url != null)
                Grp.url = (url[])vcardType.AddObjToObjArray(Grp.url, Url, typeof(url));
        }

        /// <summary>
        /// Converts a vcardType (XML formatted VCard) into a JSON formatted VCard and returns
        /// a string.
        /// </summary>
        /// <param name="vcard">Input vcardType to convert to a JSON string</param>
        /// <returns>Returns the JSON formatted VCard as a string.</returns>
        public static string XcardToJsonString(vcardType vcard)
        {
            string strRetVal = null;
            JsonWriterOptions Jwo = new JsonWriterOptions()
            {
                Indented = true
            };

            MemoryStream Ms = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(Ms, Jwo);

            // Start the JSON document as an array instead of an object.
            writer.WriteStartArray();

            writer.WriteStringValue("vcard");
            writer.WriteStartArray();   // Start the vcard array

            // version array
            writer.WriteStartArray();
            writer.WriteStringValue("version");
            writer.WriteStartObject();
            writer.WriteEndObject();
            writer.WriteStringValue("text");
            writer.WriteStringValue("4.0");
            writer.WriteEndArray();

            WriteAdrJson(vcard.adr, null, writer);
            WriteAnniversaryJson(vcard.anniversary, null, writer);
            WriteBdayJson(vcard.bday, null, writer);
            WriteCalAdrUri(vcard.caladruri, null, writer);
            WriteCalUri(vcard.caluri, null, writer);
            WriteCategories(vcard.categories, null, writer);
            WriteClientPidMap(vcard.clientpidmap, null, writer);
            WriteEmail(vcard.email, null, writer);
            WriteFburl(vcard.fburl, null, writer);
            WriteFn(vcard.fn, null, writer);
            WriteGeo(vcard.geo, null, writer);
            WriteImpp(vcard.impp, null, writer);
            WriteKey(vcard.key, null, writer);
            WriteKind(vcard.kind, null, writer);
            WriteLang(vcard.lang, null, writer);
            WriteLogo(vcard.logo, null, writer);
            WriteMember(vcard.member, null, writer);
            WriteN(vcard.n, null, writer);
            WriteNickName(vcard.nickname, null, writer);
            WriteNote(vcard.note, null, writer);
            WriteOrg(vcard.org, null, writer);
            WritePhoto(vcard.photo, null, writer);
            WriteProdid(vcard.prodid, null, writer);
            WritedRelated(vcard.related, null, writer);
            WriteRev(vcard.rev, null, writer);
            WriteRole(vcard.role, null, writer);
            WriteGender(vcard.gender, null, writer);
            WriteSound(vcard.sound, null, writer);
            WriteSource(vcard.source, null, writer);
            WriteTel(vcard.tel, null, writer);
            WriteTitle(vcard.title, null, writer);
            WriteTz(vcard.tz, null, writer);
            WriteUid(vcard.uid, null, writer);
            WriteUrl(vcard.url, null, writer);

            // Handle property groups if there are any
            if (vcard.group != null && vcard.group.Length > 0)
            {
                foreach (group Grp in vcard.group)
                {
                    if (string.IsNullOrEmpty(Grp.name) == false)
                    {
                        WriteAdrJson(Grp.adr, Grp.name, writer);
                        WriteAnniversaryJson(Grp.anniversary, Grp.name, writer);
                        WriteBdayJson(Grp.bday, Grp.name, writer);
                        WriteCalAdrUri(Grp.caladruri, Grp.name, writer);
                        WriteCalUri(Grp.caluri, Grp.name, writer);
                        WriteCategories(Grp.categories, Grp.name, writer);
                        WriteClientPidMap(Grp.clientpidmap, Grp.name, writer);
                        WriteEmail(Grp.email, Grp.name, writer);
                        WriteFburl(Grp.fburl, Grp.name, writer);
                        WriteFn(Grp.fn, Grp.name, writer);
                        WriteGeo(Grp.geo, Grp.name, writer);
                        WriteImpp(Grp.impp, Grp.name, writer);
                        WriteKey(Grp.key, Grp.name, writer);
                        WriteKind(Grp.kind, Grp.name, writer);
                        WriteLang(Grp.lang, Grp.name, writer);
                        WriteLogo(Grp.logo, Grp.name, writer);
                        WriteMember(Grp.member, Grp.name, writer);
                        WriteN(Grp.n, Grp.name, writer);
                        WriteNickName(Grp.nickname, Grp.name, writer);
                        WriteNote(Grp.note, Grp.name, writer);
                        WriteOrg(Grp.org, Grp.name, writer);
                        WritePhoto(Grp.photo, Grp.name, writer);
                        WriteProdid(Grp.prodid, Grp.name, writer);
                        WritedRelated(Grp.related, Grp.name, writer);
                        WriteRev(Grp.rev, Grp.name, writer);
                        WriteRole(Grp.role, Grp.name, writer);
                        WriteGender(Grp.gender, Grp.name, writer);
                        WriteSound(Grp.sound, Grp.name, writer);
                        WriteSource(Grp.source, Grp.name, writer);
                        WriteTel(Grp.tel, Grp.name, writer);
                        WriteTitle(Grp.title, Grp.name, writer);
                        WriteTz(Grp.tz, Grp.name, writer);
                        WriteUid(Grp.uid, Grp.name, writer);
                        WriteUrl(Grp.url, Grp.name, writer);
                    }
                }
            }

            writer.WriteEndArray();     // End the vcard array
            writer.WriteEndArray();     // End the document array
            writer.Flush();

            strRetVal = Encoding.UTF8.GetString(Ms.ToArray());
            return strRetVal;
        }

        private static void WriteAdrJson(adr[] AdrAry, string strGroupName, Utf8JsonWriter writer)
        {
            if (AdrAry == null || AdrAry.Length == 0)
                return;

            foreach (adr Adr in AdrAry)
            {
                writer.WriteStartArray();
                WritePropertyName("adr", strGroupName, writer);

                // Write the parameters
                WriteAdrParametersJson(Adr.parameters, writer);

                writer.WriteStringValue("text");
                writer.WriteStartArray();
                WriteStringArrayValue(Adr.pobox, writer);
                WriteStringArrayValue(Adr.ext, writer);
                WriteStringArrayValue(Adr.street, writer);
                WriteStringArrayValue(Adr.locality, writer);
                WriteStringArrayValue(Adr.region, writer);
                WriteStringArrayValue(Adr.code, writer);
                WriteStringArrayValue(Adr.country, writer); ;
                writer.WriteEndArray();

                writer.WriteEndArray();
            } // end foreach
        }

        private static void WriteAnniversaryJson(anniversary Ann, string strGroupName,
            Utf8JsonWriter writer)
        {
            if (Ann == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("anniversary", null, writer);

            writer.WriteStartObject();
            if (Ann.parameters != null)
            {
                WriteAltidParam(Ann.parameters.altid, writer);
                WriteCalScaleParam(Ann.parameters.calscale, writer);
            }
            writer.WriteEndObject();

            switch (Ann.ItemElementName)
            {
                case AnniversaryItemChoiceEnum.date:
                    writer.WriteStringValue("date");
                    break;
                case AnniversaryItemChoiceEnum.datetime:
                    writer.WriteStringValue("datetime");
                    break;
                case AnniversaryItemChoiceEnum.text:
                    writer.WriteStringValue("text");
                    break;
                case AnniversaryItemChoiceEnum.time:
                    writer.WriteStringValue("time");
                    break;
                case AnniversaryItemChoiceEnum.valuedateandortime:
                    writer.WriteStringValue("date-and-or-time");
                    break;
                default:
                    writer.WriteStringValue("text");
                    break;
            } // end switch

            writer.WriteStringValue(Ann.Item != null ? Ann.Item.ToString() : "");

            writer.WriteEndArray();
        }

        private static void WriteBdayJson(bday Bd, string strGroupName, Utf8JsonWriter writer)
        {
            if (Bd == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("bday", strGroupName, writer);

            writer.WriteStartObject();
            if (Bd.parameters != null)
            {
                WriteAltidParam(Bd.parameters.altid, writer);
                WriteCalScaleParam(Bd.parameters.calscale, writer);
            }
            writer.WriteEndObject();

            // Note: Cannot use ParseEnum() here because fot eh exception case of "date-and-or-time".
            switch (Bd.ItemElementName)
            {
                case BdayItemChoiceEnum.date:
                    writer.WriteStringValue("date");
                    break;
                case BdayItemChoiceEnum.datetime:
                    writer.WriteStringValue("datetime");
                    break;
                case BdayItemChoiceEnum.text:
                    writer.WriteStringValue("text");
                    break;
                case BdayItemChoiceEnum.time:
                    writer.WriteStringValue("time");
                    break;
                case BdayItemChoiceEnum.valuedateandortime:
                    writer.WriteStringValue("date-and-or-time");
                    break;
                default:
                    writer.WriteStringValue("text");
                    break;
            } // end switch

            writer.WriteStringValue(Bd.Item != null ? Bd.Item.ToString() : "");

            writer.WriteEndArray();
        }

        private static void WriteCalAdrUri(caladruri[] CalArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (CalArray == null || CalArray.Length == 0)
                return;

            foreach (caladruri Cal in CalArray)
            {
                writer.WriteStartArray();
                WritePropertyName("caladruri", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Cal.parameters != null)
                {
                    WriteAltidParam(Cal.parameters.altid, writer);
                    WritePidArrayParam(Cal.parameters.pid, writer);
                    WritePrefParam(Cal.parameters.pref, writer);
                    WriteTypeTextParam(Cal.parameters.type, writer);
                    WriteMediaTypeParam(Cal.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Cal.uri != null ? Cal.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteCalUri(caluri[] CalArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (CalArray == null || CalArray.Length == 0)
                return;

            foreach (caluri Ca in CalArray)
            {
                writer.WriteStartArray();
                WritePropertyName("caluri", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Ca.parameters != null)
                {
                    WriteAltidParam(Ca.parameters.altid, writer);
                    WritePidArrayParam(Ca.parameters.pid, writer);
                    WritePrefParam(Ca.parameters.pref, writer);
                    WriteTypeTextParam(Ca.parameters.type, writer);
                    WriteMediaTypeParam(Ca.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Ca.uri != null ? Ca.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteCategories(categories[] CatArray, string strGroupName,
            Utf8JsonWriter writer)
        {
            if (CatArray == null || CatArray.Length == 0)
                return;

            foreach (categories Cat in CatArray)
            {
                writer.WriteStartArray();
                WritePropertyName("categories", null, writer);

                // Parameters
                writer.WriteStartObject();
                if (Cat.parameters != null)
                {
                    WriteAltidParam(Cat.parameters.altid, writer);
                    WritePidArrayParam(Cat.parameters.pid, writer);
                    WritePrefParam(Cat.parameters.pref, writer);
                    WriteTypeTextParam(Cat.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                if (Cat.text != null && Cat.text.Length > 0)
                {
                    foreach (string strCat in Cat.text)
                    {
                        if (string.IsNullOrEmpty(strCat) == false)
                            writer.WriteStringValue(strCat);
                        else
                            writer.WriteStringValue("");
                    }
                }
                else
                    writer.WriteStringValue("");

                writer.WriteEndArray();
            }
        }

        private static void WriteClientPidMap(clientpidmap[] ClArray, string strGroupName,
            Utf8JsonWriter writer)
        {
            if (ClArray == null || ClArray.Length == 0)
                return;

            foreach (clientpidmap Cl in ClArray)
            {
                writer.WriteStartArray();
                WritePropertyName("clientpidmap", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                // clientpidmap has no parameters
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Cl.sourceid != null ? Cl.sourceid : "1");
                writer.WriteStringValue(Cl.uri != null ? Cl.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteEmail(email[] EmailArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (EmailArray == null || EmailArray.Length == 0)
                return;

            foreach (email Email in EmailArray)
            {
                writer.WriteStartArray();
                WritePropertyName("email", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Email.parameters != null)
                {
                    WriteAltidParam(Email.parameters.altid, writer);
                    WritePidArrayParam(Email.parameters.pid, writer);
                    WritePrefParam(Email.parameters.pref, writer);
                    WriteTypeTextParam(Email.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Email.text != null ? Email.text : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteFburl(fburl[] FbArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (FbArray == null || FbArray.Length == 0)
                return;

            foreach (fburl Fb in FbArray)
            {
                writer.WriteStartArray();
                WritePropertyName("fburl", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Fb.parameters != null)
                {
                    WriteAltidParam(Fb.parameters.altid, writer);
                    WritePidArrayParam(Fb.parameters.pid, writer);
                    WritePrefParam(Fb.parameters.pref, writer);
                    WriteTypeTextParam(Fb.parameters.type, writer);
                    WriteMediaTypeParam(Fb.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("url");
                writer.WriteStringValue(Fb.uri != null ? Fb.uri : "");
                writer.WriteEndArray();
            }
        }

        private static void WriteFn(fn[] FnArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (FnArray == null || FnArray.Length == 0)
                return;

            foreach (fn Fn in FnArray)
            {
                writer.WriteStartArray();
                WritePropertyName("fn", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Fn.parameters != null)
                {
                    WriteLanguageParam(Fn.parameters.language, writer);
                    WriteAltidParam(Fn.parameters.altid, writer);
                    WritePidArrayParam(Fn.parameters.pid, writer);
                    WritePrefParam(Fn.parameters.pref, writer);
                    WriteTypeTextParam(Fn.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Fn.text != null ? Fn.text : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteGeo(vcardTypeGeo[] GeoArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (GeoArray == null || GeoArray.Length == 0)
                return;

            foreach (vcardTypeGeo Geo in GeoArray)
            {
                writer.WriteStartArray();
                WritePropertyName("geo", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Geo.parameters != null)
                {
                    WriteAltidParam(Geo.parameters.altid, writer);
                    WritePidArrayParam(Geo.parameters.pid, writer);
                    WritePrefParam(Geo.parameters.pref, writer);
                    WriteTypeTextParam(Geo.parameters.type, writer);
                    WriteMediaTypeParam(Geo.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Geo.uri != null ? Geo.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteImpp(impp[] ImppArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (ImppArray == null || ImppArray.Length == 0)
                return;

            foreach (impp Impp in ImppArray)
            {
                writer.WriteStartArray();
                WritePropertyName("impp", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Impp.parameters != null)
                {
                    WriteAltidParam(Impp.parameters.altid, writer);
                    WritePidArrayParam(Impp.parameters.pid, writer);
                    WritePrefParam(Impp.parameters.pref, writer);
                    WriteTypeTextParam(Impp.parameters.type, writer);
                    WriteMediaTypeParam(Impp.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Impp.uri != null ? Impp.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteKey(key[] KeyArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (KeyArray == null || KeyArray.Length == 0)
                return;

            foreach (key Key in KeyArray)
            {
                writer.WriteStartArray();
                WritePropertyName("key", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Key.parameters != null)
                {
                    WriteAltidParam(Key.parameters.altid, writer);
                    WritePidArrayParam(Key.parameters.pid, writer);
                    WritePrefParam(Key.parameters.pref, writer);
                    WriteTypeTextParam(Key.parameters.type, writer);
                    WriteMediaTypeParam(Key.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue(Key.ItemElementName.ToString());
                writer.WriteStringValue(Key.Item != null ? Key.Item : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteKind(kind Kind, string strGroupName, Utf8JsonWriter writer)
        {
            if (Kind == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("kind", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            // No parameters for kind
            writer.WriteEndObject();

            writer.WriteStringValue("text");
            writer.WriteStringValue(Kind.text != null ? Kind.text : "");

            writer.WriteEndArray();
        }

        private static void WriteLang(lang[] LangArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (LangArray == null || LangArray.Length == 0)
                return;

            foreach (lang Lang in LangArray)
            {
                writer.WriteStartArray();
                WritePropertyName("lang", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Lang.parameters != null)
                {
                    WriteAltidParam(Lang.parameters.altid, writer);
                    WritePidArrayParam(Lang.parameters.pid, writer);
                    WritePrefParam(Lang.parameters.pref, writer);
                    WriteTypeTextParam(Lang.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("language-tag");
                writer.WriteStringValue(Lang.languagetag != null ? Lang.languagetag : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteLogo(logo[] LogoArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (LogoArray == null || LogoArray.Length == 0)
                return;

            foreach (logo Logo in LogoArray)
            {
                writer.WriteStartArray();
                WritePropertyName("logo", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Logo.parameters != null)
                {
                    WriteLanguageParam(Logo.parameters.language, writer);
                    WriteAltidParam(Logo.parameters.altid, writer);
                    WritePidArrayParam(Logo.parameters.pid, writer);
                    WritePrefParam(Logo.parameters.pref, writer);
                    WriteTypeTextParam(Logo.parameters.type, writer);
                    WriteMediaTypeParam(Logo.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Logo.uri != null ? Logo.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteMember(member[] MemArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (MemArray == null || MemArray.Length == 0)
                return;

            foreach (member Mem in MemArray)
            {
                writer.WriteStartArray();
                WritePropertyName("member", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Mem.parameters != null)
                {
                    WriteAltidParam(Mem.parameters.altid, writer);
                    WritePidArrayParam(Mem.parameters.pid, writer);
                    WritePrefParam(Mem.parameters.pref, writer);
                    WriteMediaTypeParam(Mem.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Mem.uri != null ? Mem.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteN(n N, string strGroupName, Utf8JsonWriter writer)
        {
            if (N == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("n", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            if (N.parameters != null)
            {
                WriteLanguageParam(N.parameters.language, writer);
                if (N.parameters.sortas != null && N.parameters.sortas.Length > 0)
                    WriteStringArrayParam(N.parameters.sortas, "sortas",writer);
                WriteAltidParam(N.parameters.altid, writer);
            }
            writer.WriteEndObject();

            writer.WriteStringValue("text");
            // Write each member of the n class as an array element
            writer.WriteStartArray();
            WriteStringArrayValue(N.surname, writer);
            WriteStringArrayValue(N.given, writer);
            WriteStringArrayValue(N.additional, writer);
            WriteStringArrayValue(N.prefix, writer);
            WriteStringArrayValue(N.suffix, writer);
            writer.WriteEndArray();

            writer.WriteEndArray();
        }

        private static void WriteNickName(nickname[] NickArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (NickArray == null || NickArray.Length == 0)
                return;

            foreach (nickname Nn in NickArray)
            {
                writer.WriteStartArray();
                WritePropertyName("nickname", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Nn.parameters != null)
                {
                    WriteLanguageParam(Nn.parameters.language, writer);
                    WriteAltidParam(Nn.parameters.altid, writer);
                    WritePidArrayParam(Nn.parameters.pid, writer);
                    WritePrefParam(Nn.parameters.pref, writer);
                    WriteTypeTextParam(Nn.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                WriteStringArrayValue(Nn.text, writer);

                writer.WriteEndArray();
            }
        }

        private static void WriteNote(note[] NoteArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (NoteArray == null || NoteArray.Length == 0)
                return;

            foreach (note Note in NoteArray)
            {
                writer.WriteStartArray();
                WritePropertyName("note", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Note.parameters != null)
                {
                    WriteLanguageParam(Note.parameters.language, writer);
                    WriteAltidParam(Note.parameters.altid, writer);
                    WritePidArrayParam(Note.parameters.pid, writer);
                    WritePrefParam(Note.parameters.pref, writer);
                    WriteTypeTextParam(Note.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Note.text != null ? Note.text : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteOrg(org[] OrgArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (OrgArray == null || OrgArray.Length == 0)
                return;

            foreach (org Org in OrgArray)
            {
                writer.WriteStartArray();
                WritePropertyName("org", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Org.parameters != null)
                {
                    WriteLanguageParam(Org.parameters.language, writer);
                    WriteAltidParam(Org.parameters.altid, writer);
                    WritePidArrayParam(Org.parameters.pid, writer);
                    WritePrefParam(Org.parameters.pref, writer);
                    WriteTypeTextParam(Org.parameters.type, writer);
                    WriteStringArrayParam(Org.parameters.sortas, "sortas", writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                WriteStringArrayValue(Org.text, writer);

                writer.WriteEndArray();
            }
        }

        private static void WritePhoto(photo[] PhotoArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (PhotoArray == null || PhotoArray.Length == 0)
                return;

            foreach (photo Photo in PhotoArray)
            {
                writer.WriteStartArray();
                WritePropertyName("photo", null, writer);

                // Parameters
                writer.WriteStartObject();
                if (Photo.parameters != null)
                {
                    WriteAltidParam(Photo.parameters.altid, writer);
                    WritePidArrayParam(Photo.parameters.pid, writer);
                    WritePrefParam(Photo.parameters.pref, writer);
                    WriteTypeTextParam(Photo.parameters.type, writer);
                    WriteMediaTypeParam(Photo.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Photo.uri != null ? Photo.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteProdid(prodid Prodid, string strGroupName, Utf8JsonWriter writer)
        {
            if (Prodid == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("prodid", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            // prodid has no parameters
            writer.WriteEndObject();

            writer.WriteStringValue("text");
            writer.WriteStringValue(Prodid.text != null ? Prodid.text : "");

            writer.WriteEndArray();
        }

        private static void WritedRelated(related[] RelatedArray, string strGroupName, 
            Utf8JsonWriter writer)
        {
            if (RelatedArray == null || RelatedArray.Length == 0)
                return;

            foreach (related Rel in RelatedArray)
            {
                writer.WriteStartArray();
                WritePropertyName("related", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                WriteAltidParam(Rel.parameters.altid, writer);
                WritePidArrayParam(Rel.parameters.pid, writer);
                WritePrefParam(Rel.parameters.pref, writer);

                if (Rel.parameters.type != null && Rel.parameters.type.Length > 0)
                {
                    writer.WritePropertyName("type");
                    if (Rel.parameters.type.Length == 1)
                        writer.WriteStringValue(Rel.parameters.type[0].ToString());
                    else
                    {
                        writer.WriteStartArray();
                        foreach (relatedParametersText Rpt in Rel.parameters.type)
                            writer.WriteStringValue(Rpt.ToString());
                        writer.WriteEndArray();
                    }
                }

                WriteMediaTypeParam(Rel.parameters.mediatype, writer);

                writer.WriteEndObject();

                writer.WriteStringValue(Rel.ItemElementName.ToString());
                writer.WriteStringValue(Rel.Item != null ? Rel.Item : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteRev(valuetimestamp Vt, string strGroupName, Utf8JsonWriter writer)
        {
            if (Vt == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("rev", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            // The valuetimestamp type has no parameters
            writer.WriteEndObject();

            writer.WriteStringValue("text");
            writer.WriteStringValue(Vt.timestamp != null ? Vt.timestamp : "");

            writer.WriteEndArray();
        }

        private static void WriteRole(role[] RoleArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (RoleArray == null || RoleArray.Length == 0)
                return;

            foreach (role Role in RoleArray)
            {
                writer.WriteStartArray();
                WritePropertyName("role", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Role.parameters != null)
                {
                    WriteLanguageParam(Role.parameters.language, writer);
                    WriteAltidParam(Role.parameters.altid, writer);
                    WritePidArrayParam(Role.parameters.pid, writer);
                    WritePrefParam(Role.parameters.pref, writer);
                    WriteTypeTextParam(Role.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Role.text != null ? Role.text : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteGender(gender Gen, string strGroupName, Utf8JsonWriter writer)
        {
            if (Gen == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("gender", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            // The gender type has no parameters
            writer.WriteEndObject();

            writer.WriteStringValue("text");
            writer.WriteStringValue(Gen.sex.ToString());
            if (string.IsNullOrEmpty(Gen.identity) == false)
                writer.WriteStringValue(Gen.identity);

            writer.WriteEndArray();
        }

        private static void WriteSound(sound[] SndArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (SndArray == null || SndArray.Length == 0)
                return;

            foreach (sound Snd in SndArray)
            {
                writer.WriteStartArray();
                WritePropertyName("sound", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Snd.parameters != null)
                {
                    WriteLanguageParam(Snd.parameters.language, writer);
                    WriteAltidParam(Snd.parameters.altid, writer);
                    WritePidArrayParam(Snd.parameters.pid, writer);
                    WritePrefParam(Snd.parameters.pref, writer);
                    WriteTypeTextParam(Snd.parameters.type, writer);
                    WriteMediaTypeParam(Snd.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Snd.uri != null ? Snd.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteSource(source[] SrcArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (SrcArray == null || SrcArray.Length == 0)
                return;

            foreach (source Src in SrcArray)
            {
                writer.WriteStartArray();
                WritePropertyName("source", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Src.parameters != null)
                {
                    WriteAltidParam(Src.parameters.altid, writer);
                    WritePidArrayParam(Src.parameters.pid, writer);
                    WritePrefParam(Src.parameters.pref, writer);
                    WriteMediaTypeParam(Src.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Src.uri != null ? Src.uri : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteTel(tel[] TelArray, string strGroupType, Utf8JsonWriter writer)
        {
            if (TelArray == null || TelArray.Length == 0)
                return;

            foreach(tel Tel in TelArray)
            {
                writer.WriteStartArray();
                WritePropertyName("tel", strGroupType, writer);

                // Parameters
                writer.WriteStartObject();
                if (Tel.parameters != null)
                {
                    WriteAltidParam(Tel.parameters.altid, writer);
                    WritePidArrayParam(Tel.parameters.pid, writer);
                    WritePrefParam(Tel.parameters.pref, writer);
                    WriteStringArrayParam(Tel.parameters.type, "type", writer);
                    WriteMediaTypeParam(Tel.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue(Tel.ItemElementName.ToString());
                writer.WriteStringValue(Tel.Item != null ? Tel.Item : "");

                writer.WriteEndArray();
            }

        }

        private static void WriteTitle(title[] TitleArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (TitleArray == null || TitleArray.Length == 0)
                return;

            foreach (title Title in TitleArray)
            {
                writer.WriteStartArray();
                WritePropertyName("tltle", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Title.parameters != null)
                {
                    WriteLanguageParam(Title.parameters.language, writer);
                    WriteAltidParam(Title.parameters.altid, writer);
                    WritePidArrayParam(Title.parameters.pid, writer);
                    WritePrefParam(Title.parameters.pref, writer);
                    WriteTypeTextParam(Title.parameters.type, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("text");
                writer.WriteStringValue(Title.text != null ? Title.text : "");

                writer.WriteEndArray();
            }
        }

        private static void WriteTz(vcardTypeTZ[] TzArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (TzArray == null || TzArray.Length == 0)
                return;

            foreach (vcardTypeTZ Tz in TzArray)
            {
                writer.WriteStartArray();
                WritePropertyName("tz", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Tz.parameters != null)
                {
                    WriteAltidParam(Tz.parameters.altid, writer);
                    WritePidArrayParam(Tz.parameters.pid, writer);
                    WritePrefParam(Tz.parameters.pref, writer);
                    WriteTypeTextParam(Tz.parameters.type, writer);
                    WriteMediaTypeParam(Tz.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                switch (Tz.ItemElementName)
                {
                    case VcardTypeTzItemChoiceEnum.text:
                        writer.WriteStringValue("text");
                        break;
                    case VcardTypeTzItemChoiceEnum.uri:
                        writer.WriteStringValue("uri");
                        break;
                    case VcardTypeTzItemChoiceEnum.utcoffset:
                        writer.WriteStringValue("utc-offset");
                        break;
                    default:
                        writer.WriteStringValue("text");
                        break;
                }

                writer.WriteStringValue(Tz.Item != null ? Tz.Item : "");
                
                writer.WriteEndArray();
            }
        }

        private static void WriteUid(uid Uid, string strGroupName, Utf8JsonWriter writer)
        {
            if (Uid == null)
                return;

            writer.WriteStartArray();
            WritePropertyName("uid", strGroupName, writer);

            // Parameters
            writer.WriteStartObject();
            // The uid type has no parameters
            writer.WriteEndObject();

            writer.WriteStringValue("uri");
            writer.WriteStringValue(Uid.uri != null ? Uid.uri : "");

            writer.WriteEndArray();
        }

        private static void WriteUrl(url[] UrlArray, string strGroupName, Utf8JsonWriter writer)
        {
            if (UrlArray == null || UrlArray.Length == 0)
                return;

            foreach (url Url in UrlArray)
            {
                writer.WriteStartArray();
                WritePropertyName("url", strGroupName, writer);

                // Parameters
                writer.WriteStartObject();
                if (Url.parameters != null)
                {
                    WriteAltidParam(Url.parameters.altid, writer);
                    WritePidArrayParam(Url.parameters.pid, writer);
                    WritePrefParam(Url.parameters.pref, writer);
                    WriteTypeTextParam(Url.parameters.type, writer);
                    WriteMediaTypeParam(Url.parameters.mediatype, writer);
                }
                writer.WriteEndObject();

                writer.WriteStringValue("uri");
                writer.WriteStringValue(Url.uri);

                writer.WriteEndArray();
            }
        }

        private static void WritePropertyName(string strPropName, string strGroupName,
            Utf8JsonWriter writer)
        {
            if (strGroupName == null)
                writer.WriteStringValue(strPropName);
            else
                writer.WriteStringValue(strPropName + "." + strGroupName);
        }

        private static void WriteAdrParametersJson(adrParameters Ap, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Ap != null)
            {
                WriteLanguageParam(Ap.language, writer);
                WriteAltidParam(Ap.altid, writer);
                WriteStringArrayParam(Ap.pid, "pid", writer);
                WritePrefParam(Ap.pref, writer);
                WriteTypeTextParam(Ap.type, writer);

                if (Ap.geo != null)
                    writer.WriteString("geo", Ap.geo.uri != null ? Ap.geo.uri : "");

                if (Ap.tz != null)
                    writer.WriteString("tz", Ap.tz.Item != null ? Ap.tz.Item : "");

                if (Ap.label != null)
                    writer.WriteString("label", Ap.label.text != null ? Ap.label.text : "");
            }
            writer.WriteEndObject();
        }

        private static void WriteTypeTextParam(typeText[] TtArray, Utf8JsonWriter writer)
        {
            if (TtArray == null || TtArray.Length == 0)
                return;

            if (TtArray.Length == 1)
                writer.WriteString("type", TtArray[0].ToString());
            else
            {
                writer.WritePropertyName("type");
                writer.WriteStartArray();
                foreach (typeText Tt in TtArray)
                    writer.WriteStringValue(Tt.ToString());
                writer.WriteEndArray();
            }
        }

        private static void WritePidArrayParam(string[] PidArray, Utf8JsonWriter writer)
        {
            if (PidArray == null || PidArray.Length == 0)
                return;

            if (PidArray.Length == 1)
                writer.WriteString("pid", PidArray[0].ToString());
            else
            {
                writer.WritePropertyName("pid");
                writer.WriteStartArray();
                foreach (string strPid in PidArray)
                    writer.WriteStringValue(strPid);
                writer.WriteEndArray();
            }
        }

        private static void WriteMediaTypeParam(mediatype Mt, Utf8JsonWriter writer)
        {
            if (Mt?.text == null)
                return;

            writer.WriteString("mediatype", Mt.text);
        }

        private static void WritePrefParam(pref Pr, Utf8JsonWriter writer)
        {
            if (Pr != null)
                writer.WriteString("pref", Pr.integer);
        }

        private static void WriteLanguageParam(language lang, Utf8JsonWriter writer)
        {
            if (lang != null)
                writer.WriteString("language", lang.languagetag);
        }

        private static void WriteAltidParam(altid Alt, Utf8JsonWriter writer)
        {
            if (Alt != null)
                writer.WriteString("altid", Alt.text);
        }

        private static void WriteCalScaleParam(calscale Cs, Utf8JsonWriter writer)
        {
            if (Cs != null)
                writer.WriteString("calscale", Cs.text.ToString());
        }

        private static void WriteStringArrayParam(string[] StrAry, string ParamName, Utf8JsonWriter writer)
        {
            if (StrAry == null || StrAry.Length == 0)
                return;

            writer.WritePropertyName(ParamName);
            if (StrAry.Length == 1)
                writer.WriteStringValue(StrAry[0]);
            else
            {
                writer.WriteStartArray();
                foreach (string str in StrAry)
                    writer.WriteStringValue(str);
                writer.WriteEndArray();
            }
        }

        private static void WriteStringArrayValue(string[] Ary, Utf8JsonWriter writer)
        {
            if (Ary == null || Ary.Length == 0)
                writer.WriteStringValue("");
            else
            {
                if (Ary.Length == 1)
                    // Write it as a string
                    writer.WriteStringValue(Ary[0]);
                else
                {   // Write it as an array of strings
                    writer.WriteStartArray();
                    foreach (string str in Ary)
                        writer.WriteStringValue(str);
                    writer.WriteEndArray();
                }
            }
        }
    }
}
