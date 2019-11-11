﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using PagedList;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using Horizone.Controllers;
using Rotativa;

namespace Horizone.Controllers
{
    public class VocabulariesController : BaseController
    {
        // GET: Vocabularies

        public ActionResult Vocabulaire(int page = 1, int pageSize = 50)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }
        public ActionResult Parallel(int page = 1, int pageSize = 50)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.EquivalentTA).ToPagedList(page, pageSize));
        }
        
        public ActionResult TocharianA(int page = 1, int pageSize = 50)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x =>x.TochLanguage.Language.Contains("TA")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }
        public ActionResult TocharianB(int page = 1, int pageSize = 50)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x => x.TochLanguage.Language.Contains("TB")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }
        public ActionResult Verb()
        {
            var verbs = db.Verbs.Where(x => x.WordClass.ClassEn == "Verb").Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").Include("Persons");
            return View(verbs.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult Adverb()
        {
            var otherWords = db.OtherWords.Where(x => x.WordClass.ClassEn == "Adverb"|| x.WordSubClass.SubClassEn =="Adverb").Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers");
            return View(otherWords.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult Noun()
        {
            var nounAdjectives = db.NounAdjectives.Where(x => x.WordClass.ClassEn == "Noun").Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult Pronoun()
        {
            var pronouns = db.Pronouns.Where(x => x.WordClass.ClassEn == "Pronoun").Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons");
            return View(pronouns.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult AllProperNoun()
        {
            return View(db.ProperNouns.OrderBy(x => x.Name).ToList());
        }
        public ActionResult Adjective()
        {
            var nounAdjectives = db.NounAdjectives.Where(x => x.WordClass.ClassEn == "Adjective").Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult OtherWord()
        {
            var otherWords = db.OtherWords.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers");
            return View(otherWords.OrderBy(x => x.TochWord).ToList());
        }
        public ActionResult Abbreviation(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.OtherAbbreviation == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationGrammatical(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.GrammaticalAbbreviation == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationLanguage(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.AbbreviationsLanguage == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationManuscript(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x=>x.AbbreviationManuscript==true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult Reverse(int page = 1, int pageSize = 30)
        {
            var reverseDictionaries = db.ReverseDictionaries;
            return View(reverseDictionaries.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }
       
        public ActionResult PrintVocabulaire()
        {
            var report = new ActionAsPdf("Vocabulaire");
            return report;
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).SingleOrDefault(y => y.Id == id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }
        public ActionResult DetailsVerb(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").Include("Persons").SingleOrDefault(y => y.Id == id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }
        public ActionResult DetailsOtherWord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord  = db.OtherWords.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").SingleOrDefault(y => y.Id == id);
            if (otherWord == null)
            {
                return HttpNotFound();
            }
            return View(otherWord);
        }
        public ActionResult DetailsNoun(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NounAdjective nounAdjective = db.NounAdjectives.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").SingleOrDefault(y => y.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            return View(nounAdjective);
        }
        public ActionResult DetailsPronoun(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pronoun pronoun = db.Pronouns.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            if (pronoun == null)
            {
                return HttpNotFound();
            }
            return View(pronoun);
        }
        public ActionResult RefreshSearch()
        {
            foreach (var item in db.SearchResults)
            {
                db.SearchResults.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("SearchWord");
        }
        public ActionResult SearchWord(string search)
        {
            RefreshSearch();
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("WordClass").Include("WordSubClass");
            IEnumerable<Verb> verbs = db.Verbs.Include("WordClass").Include("WordSubClass").Include("Voice").Include("Valency").Include("TenseAndAspect").Include(" Mood").Include("Persons");
            IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include("WordClass").Include("WordSubClass").Include("Genders").Include("Cases");
            IEnumerable<Pronoun> pronouns = db.Pronouns.Include("WordClass").Include("WordSubClass").Include("Genders").Include("Cases").Include("Persons");
            IEnumerable<OtherWord> otherWords = db.OtherWords.Include("WordClass").Include("WordSubClass");
            IEnumerable<NamePlace> namePlaces = db.NamePlaces;
            IEnumerable<ProperNoun> properNouns = db.ProperNouns;
            List<SearchResult> searchResults = new List<SearchResult>();
            if (!string.IsNullOrWhiteSpace(search))
            {               
                properNouns = db.ProperNouns.Where(x => x.Name.Contains(search));
                if (properNouns.Count() != 0)
                {
                    foreach (var item in properNouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "ProperNouns", IdResult = item.Id, Summary = item.Name });
                    }
                }
                verbs = db.Verbs.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))                
                );
                if (verbs.Count() != 0)
                {
                    foreach (var item in verbs)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Verbs", IdResult = item.Id, Summary = (item.TochWord + "- " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Substring(0, Math.Min(40, (item.TochWord + " " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Length)) });
                    }
                }
                nounAdjectives = db.NounAdjectives.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
                );
                if (nounAdjectives.Count() != 0)
                {
                    foreach (var item in nounAdjectives)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NounAdjectives", IdResult = item.Id, Summary = (item.TochWord + "- " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Substring(0, Math.Min(40, (item.TochWord + " " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Length)) });
                    }
                }
                pronouns = db.Pronouns.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
              );
                if (pronouns.Count() != 0)
                {
                    foreach (var item in pronouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Pronouns", IdResult = item.Id, Summary = (item.TochWord + "- " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Substring(0, Math.Min(40, (item.TochWord + " " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Length)) });
                    }
                }
                otherWords = db.OtherWords.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
              );
                if (otherWords.Count() != 0)
                {
                    foreach (var item in otherWords)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "OtherWords", IdResult = item.Id, Summary = (item.TochWord + "- " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Substring(0, Math.Min(40, (item.TochWord + " " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Length)) });
                    }
                }
                namePlaces = db.NamePlaces.Where(x => x.Place.Contains(search));
                if (namePlaces.Count() != 0)
                {
                    foreach (var item in namePlaces)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NamePlaces", IdResult = item.Id, Summary = item.Place + " " + item.DescriptionEn });
                    }
                }
                dictionaryTocharians = db.DictionaryTocharians.Where(x => x.Word.Contains(search)
                || (x.EquivalentTA != null && x.EquivalentTA.Contains(search))
                || (x.EquivalentTB != null && x.EquivalentTB.Contains(search))
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search)));
                if (dictionaryTocharians.Count() != 0)
                {
                    foreach (var item in dictionaryTocharians)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "DictionaryTocharians", IdResult = item.Id, Summary = (item.Word + "- " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Substring(0, Math.Min(40, (item.Word + " " + item.English + " " + item.Francaise + " - " + item.German + " - " + item.Latin).Length)) });
                    }
                }

                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
            return View("SearchWord", db.SearchResults.ToList());
           
        }
                
        public ActionResult SearchAbbreviation(string search)
        {
            IEnumerable<AbbreviationDictionary> abbreviationDictionarys = db.AbbreviationDictionaries;
            IEnumerable<Abreviation> abbreviations = db.Abreviations;

            List<SearchResult> searchResults = new List<SearchResult>();
            foreach (var item in db.SearchResults)
            {
                db.SearchResults.Remove(item);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

                abbreviationDictionarys = db.AbbreviationDictionaries.Where(x => x.Symbol == search);
                if (abbreviationDictionarys.Count() != 0)
                {
                    foreach (var item in abbreviationDictionarys)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "AbbreviationDictionaries", IdResult = item.Id, Summary = item.Description });
                    }
                }
                abbreviations = db.Abreviations.Where(x => x.Symbol == search);                           
                if (abbreviations.Count() != 0)
                {
                    foreach (var item in abbreviations)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Abbreviations", IdResult = item.Id, Summary = (item.Symbol + " - " + item.Description) });
                    }
                }
              
                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
            return View("SearchAbbreviation", db.SearchResults.ToList());
        }
        // GET: BackOffice/Verbs/Details/5
        public ActionResult DetailsAbbreviationDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.SingleOrDefault(y => y.Id == id);

            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }
        public ActionResult SearchReverse(string search)
        {
            IEnumerable<ReverseDictionary> reverseDictionarys = db.ReverseDictionaries;

            if (!string.IsNullOrWhiteSpace(search))
            {
                reverseDictionarys = reverseDictionarys.Where(x=>x.ReverseWord.Contains(search));
            }
            if (reverseDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchReverse", reverseDictionarys.ToList());
        }
        
        public ActionResult SearchEnd(string search)
        {
            IEnumerable<ReverseDictionary> reverseDictionarys = db.ReverseDictionaries;

            if (!string.IsNullOrWhiteSpace(search))
            {
                int i = search.Length;
                reverseDictionarys = reverseDictionarys.Where(x => x.ReverseWord.Length >=i &&  x.ReverseWord.Substring(x.ReverseWord.Length-i,i) ==search);
            }
            if (reverseDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchReverse", reverseDictionarys.ToList());
        }
    }
}