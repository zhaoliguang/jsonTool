using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Trail
    {
        public Trail()
        {
            learnings = new List<Learning>();
            judges = new List<Judgment>();
            matchs = new List<Match>();
            choices = new List<Choice>();
            puzzles = new List<Puzzle>();
            draws = new List<Draw>();
         }
        private List<Learning> learnings;

        public List<Learning> Learnings
        {
            get { return learnings; }
            set { learnings = value; }
        }
        private List<Judgment> judges;

        public List<Judgment> Judges
        {
            get { return judges; }
            set { judges = value; }
        }


        private List<Match> matchs;

        public List<Match> Matchs
        {
            get { return matchs; }
            set { matchs = value; }
        }
        private List<Choice> choices;

        public List<Choice> Choices
        {
            get { return choices; }
            set { choices = value; }
        }
        private List<Puzzle> puzzles;

        public List<Puzzle> Puzzles
        {
            get { return puzzles; }
            set { puzzles = value; }
        }


        private List<Draw> draws;

        public List<Draw> Draws
        {
            get { return draws; }
            set { draws = value; }
        }


    }
}
