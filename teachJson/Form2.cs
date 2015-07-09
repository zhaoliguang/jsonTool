﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace teachJson
{
    public partial class Form2 : Form
    {
        private SqlHelper dbhelper;
        public Form2()
        {
            InitializeComponent();
            dbhelper = new SqlHelper();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trail trail = new Trail();
            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if(!this.tabcontrol0learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol0LearnExciseName.Text;
                learning.QuestionType = "learning";
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol0LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol0learnSound.Text;
                learning.Question.Text = this.tabcontr0LearnKeyText.Text;
              
                learning.PinYing = this.tabcontrol0LearnPy.Text;
                string strSerializeJSON = JsonConvert.SerializeObject(learning);
               // MessageBox.Show(strSerializeJSON);


            }
            if (!this.tabcontrol0JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol0JudgeExciseName.Text;
                judgment.Speech = this.tabcontro0JudgeSound.Text;
                judgment.QuestionType = "judge";
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol0JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol0JudgeWrongImage.Text;
           
                

                string judgeSerializeJSON = JsonConvert.SerializeObject(judgment);
              //  MessageBox.Show(judgeSerializeJSON);

            }
         if (!this.tabcontrol0MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = tabcontrol0MatchExciseName.Text;
                match.QuestionType = this.tabcontrol0MatchQuestionType.Text;
                match.Speech = this.tabcontrol0MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol0MatchQuestionImage.Text;
                        match.Answer = new ImageItem();
                match.Answer.Image=this.tabcontrol0MatchAnswerImage.Text;
                 match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol0MatchDistraImage.Text;
              
                string matchSerializeJSON = JsonConvert.SerializeObject(match);
             //   MessageBox.Show(matchSerializeJSON);

                }
            if(!this.tabcontrol0ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol0ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol0ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol0ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol0ChoiceRightImage.Text;
                choice.Answer.Text = this.tabcontrol0ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol0ChoiceDistraImage.Text;
                choice.Distractor.Text = this.tabcontrol0ChoiceRightText.Text;
  
                string choiceSerializeJSON = JsonConvert.SerializeObject(choice);
            //    MessageBox.Show(choiceSerializeJSON);
                
            }
            if (!this.tabcontrol0PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol0PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol0PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol0PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol0PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol0PuzzleDistraImage.Text;
               
             
                string puzzleSerializeJSON = JsonConvert.SerializeObject(puzzle);
               // MessageBox.Show(puzzleSerializeJSON);
            
            }

            trail.Choices.Add(choice);
            trail.Learnings.Add(learning);
            trail.Matchs.Add(match);
            trail.Puzzles.Add(puzzle);
            trail.Judges.Add(judgment);
            string lessonname = this.lessonName.Text;
            string trailname = this.trailName.Text;
            string trailChineseName = this.trailChineseName.Text;

       

            string trailSerializeJSON = JsonConvert.SerializeObject(trail);
            Console.WriteLine(trailSerializeJSON);
            string sql = "insert into lessontrail (lessonName, trialName,chineseName,jsondata) values ('"+lessonname+"','"+ trailname+"','"+trailChineseName+"',"+"'"+trailSerializeJSON+"'"+")";
            dbhelper.RunSQL(sql);
            MessageBox.Show(trailSerializeJSON);


        }

        private string[] getFile(string images)
        {
            string [] files = images.Split(';');
            return files;

        }
        private string selectPathFromBrowser()
        {
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            const string givenPath = "D:\\picture\\";
            m_Dialog.SelectedPath = givenPath;
            DialogResult result = m_Dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return string.Empty;
            }
            string m_Dir = m_Dialog.SelectedPath.Trim();
            if (m_Dir.Length > givenPath.Length)
            {
                string comparedPath = m_Dir.Substring(0, givenPath.Length);
                if (comparedPath.Equals(givenPath))
                {
                    string resultString = m_Dir.Substring(givenPath.Length);
                    resultString = resultString.Replace('\\', ':');
                    return resultString;
                }
                else
                {
                    MessageBox.Show("请选择正确的文件路径");
                    return string.Empty;
                }
            }
            else {
                MessageBox.Show("请选择正确的文件路径");
                return string.Empty;
            }
         
          
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0LearnImage.Text += path + ";";
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0JudgeRightImage.Text += path + ";";
       

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0JudgeWrongImage.Text += path+ ";";
       
           
        }

        private void matchSound_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0MatchQuestionImage.Text += path + ";";
          
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0MatchAnswerImage.Text += path + ";";
         
          
    
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0MatchDistraImage.Text += path + ";";
         
       
          
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0PuzzleRightImage.Text += path + ";";
         

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0MatchDistraImage.Text += path + ";";
         
         
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0ChoiceRightImage.Text += path + ";";
        
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0ChoiceDistraImage.Text += path + ";";
            
          
         
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void puzzleImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button142_Click(object sender, EventArgs e)
        {
            Trail trail = new Trail();

            addTabcontrol0(trail);
            addTabcontrol1(trail);
            addTabcontrol2(trail);
            addTabcontrol3(trail);
            addTabcontrol4(trail);
            addTabcontrol5(trail);
            addTabcontrol6(trail);
            addTabcontrol7(trail);
            addTabcontrol8(trail);
            addTabcontrol9(trail);
            addTabcontrol10(trail);
            addTabcontrol11(trail);
            addTabcontrol12(trail);
            addTabcontrol13(trail);
            string lessonname = this.lessonName.Text;
            string trailname = this.trailName.Text;
            string trailChineseName = this.trailChineseName.Text;
            string trailSerializeJSON = JsonConvert.SerializeObject(trail);
            Console.WriteLine(trailSerializeJSON);
            string sql = "insert into lessontrail (lessonName, trialName,chineseName,jsondata) values ('" + lessonname + "','" + trailname + "','" + trailChineseName + "'," + "'" + trailSerializeJSON + "'" + ")";
            dbhelper.RunSQL(sql);
            MessageBox.Show(trailSerializeJSON);
        }
        private void addTabcontrol0(Trail trail)
        {
        
            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol0learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol0LearnExciseName.Text;
                learning.QuestionType = "learning";
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol0LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol0learnSound.Text;
                learning.Question.Text = this.tabcontr0LearnKeyText.Text;

                learning.PinYing = this.tabcontrol0LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
             else if (!this.tabcontrol0JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol0JudgeExciseName.Text;
                judgment.Speech = this.tabcontro0JudgeSound.Text;
                judgment.QuestionType = "judge";
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol0JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol0JudgeWrongImage.Text;
                trail.Judges.Add(judgment);
                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol0MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = tabcontrol0MatchExciseName.Text;
                match.QuestionType = this.tabcontrol0MatchQuestionType.Text;
                match.Speech = this.tabcontrol0MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol0MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol0MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol0MatchDistraImage.Text;
                trail.Matchs.Add(match);

            }
            else if (!this.tabcontrol0ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol0ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol0ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol0ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol0ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol0ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol0ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol0ChoiceRightText.Text;

                trail.Choices.Add(choice);
                //    MessageBox.Show(choiceSerializeJSON);

            }
            else if (!this.tabcontrol0PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol0PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol0PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol0PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol0PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol0PuzzleDistraImage.Text;


                trail.Puzzles.Add(puzzle);
                // MessageBox.Show(puzzleSerializeJSON);

            }
             
        }


        private void addTabcontrol1(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol1learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol1LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol1learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol1LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol1learnSound.Text;
                learning.Question.Text = this.tabcontrl1LearnKeyText.Text;

                learning.PinYing = this.tabcontrol1LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol1JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol1JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol1JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol1JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol1JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol1JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol1MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol1MatchExciseName.Text;
                match.QuestionType = this.tabcontrol1MatchQuestionType.Text;
                match.Speech = this.tabcontrol1MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol1MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol1MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol1MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol1ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol1ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol1ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol1ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol1ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol1ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol1ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol1ChoiceDistraText.Text;

                trail.Choices.Add(choice);
                

            }
            else if (!this.tabcontrol1PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol1PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol1PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol1PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol1PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol1PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol2(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol2learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol2LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol2learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol2LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol2learnSound.Text;
                learning.Question.Text = this.tabcontrl2LearnKeyText.Text;

                learning.PinYing = this.tabcontrol2LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol2JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol2JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol2JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol2JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol2JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol2JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol2MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol2MatchExciseName.Text;
                match.QuestionType = this.tabcontrol2MatchQuestionType.Text;
                match.Speech = this.tabcontrol2MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol2MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol2MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol2MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol2ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol2ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol2ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol2ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol2ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol2ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol2ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol2ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol2PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol2PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol2PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol2PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol2PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol2PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol3(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol3learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol3LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol3learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol3LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol3learnSound.Text;
                learning.Question.Text = this.tabcontrl3LearnKeyText.Text;

                learning.PinYing = this.tabcontrol3LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol3JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol3JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol3JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol3JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol3JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol3JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol3MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol3MatchExciseName.Text;
                match.QuestionType = this.tabcontrol3MatchQuestionType.Text;
                match.Speech = this.tabcontrol3MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol3MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol3MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol3MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol3ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol3ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol3ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol3ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol3ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol3ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol3ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol3ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol3PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol3PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol3PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol3PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol3PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol3PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        private void addTabcontrol4(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol4learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol4LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol4learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol4LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol4learnSound.Text;
                learning.Question.Text = this.tabcontrl3LearnKeyText.Text;

                learning.PinYing = this.tabcontrol4LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol4JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol4JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol4JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol4JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol4JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol4JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol4MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol4MatchExciseName.Text;
                match.QuestionType = this.tabcontrol4MatchQuestionType.Text;
                match.Speech = this.tabcontrol4MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol4MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol4MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol4MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol4ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol4ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol4ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol4ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol4ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol4ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol4ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol4ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol4PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol4PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol4PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol4PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol4PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol4PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        private void addTabcontrol5(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol5learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol5LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol5learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol5LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol5learnSound.Text;
                learning.Question.Text = this.tabcontrl5LearnKeyText.Text;

                learning.PinYing = this.tabcontrol5LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol5JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol5JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol5JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol5JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol5JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol5JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol5MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol5MatchExciseName.Text;
                match.QuestionType = this.tabcontrol5MatchQuestionType.Text;
                match.Speech = this.tabcontrol5MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol5MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol5MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol5MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol5ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol5ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol5ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol5ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol5ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol5ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol5ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol5ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol5PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol5PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol5PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol5PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol5PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol5PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        private void addTabcontrol6(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol6learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol6LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol6learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol6LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol6learnSound.Text;
                learning.Question.Text = this.tabcontrl6LearnKeyText.Text;

                learning.PinYing = this.tabcontrol6LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol6JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol6JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol6JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol6JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol6JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol6JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol6MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol6MatchExciseName.Text;
                match.QuestionType = this.tabcontrol6MatchQuestionType.Text;
                match.Speech = this.tabcontrol6MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol6MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol6MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol6MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol6ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol6ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol6ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol6ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol6ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol6ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol6ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol6ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol6PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol6PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol6PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol6PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol6PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol6PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        private void addTabcontrol7(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol7learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol7LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol7learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol7LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol7learnSound.Text;
                learning.Question.Text = this.tabcontrl7LearnKeyText.Text;

                learning.PinYing = this.tabcontrol7LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol7JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol7JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol7JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol7JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol7JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol7JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol7MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol7MatchExciseName.Text;
                match.QuestionType = this.tabcontrol7MatchQuestionType.Text;
                match.Speech = this.tabcontrol7MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol7MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol7MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol7MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol7ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol7ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol7ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol7ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol7ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol7ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol7ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol7ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol7PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol7PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol7PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol7PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol7PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol7PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol8(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol8learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol8LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol8learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol8LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol8learnSound.Text;
                learning.Question.Text = this.tabcontrl8LearnKeyText.Text;

                learning.PinYing = this.tabcontrol8LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol8JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol8JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol8JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol8JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol8JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol8JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol8MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol8MatchExciseName.Text;
                match.QuestionType = this.tabcontrol8MatchQuestionType.Text;
                match.Speech = this.tabcontrol8MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol8MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol8MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol8MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol8ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol8ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol8ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol8ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol8ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol8ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol8ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol8ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol8PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol8PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol8PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol8PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol8PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol8PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        private void addTabcontrol9(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol9learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol9LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol9learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol9LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol9learnSound.Text;
                learning.Question.Text = this.tabcontrl9LearnKeyText.Text;

                learning.PinYing = this.tabcontrol9LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol9JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol9JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol9JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol9JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol9JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol9JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol9MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol9MatchExciseName.Text;
                match.QuestionType = this.tabcontrol9MatchQuestionType.Text;
                match.Speech = this.tabcontrol9MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol9MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol9MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol9MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol9ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol9ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol9ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol9ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol9ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol9ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol9ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol9ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol9PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol9PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol9PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol9PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol9PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol9PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol10(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol10MatchQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol10LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol10learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol10LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol10learnSound.Text;
                learning.Question.Text = this.tabcontrl10LearnKeyText.Text;

                learning.PinYing = this.tabcontrol10LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol10JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol10JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol10JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol10JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol10JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol10JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol10MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol10MatchExciseName.Text;
                match.QuestionType = this.tabcontrol10MatchQuestionType.Text;
                match.Speech = this.tabcontrol10MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol10MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol10MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol10MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol10ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol10ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol10ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol10ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol10ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol10ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol10ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol10ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol10PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol10PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol10PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol10PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol10PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol10PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol11(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol11MatchQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol11LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol11learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol11LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol11learnSound.Text;
                learning.Question.Text = this.tabcontrl11LearnKeyText.Text;

                learning.PinYing = this.tabcontrol11LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol11JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol11JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol11JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol11JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol11JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol11JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol1MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol11MatchExciseName.Text;
                match.QuestionType = this.tabcontrol11MatchQuestionType.Text;
                match.Speech = this.tabcontrol11MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol11MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol11MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol11MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol11ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol11ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol11ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol11ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol11ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol11ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol11ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol11ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol11PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol11PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol11PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol11PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol11PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol11PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol12(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol12learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol12LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol12learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol12LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol12learnSound.Text;
                learning.Question.Text = this.tabcontrl12LearnKeyText.Text;

                learning.PinYing = this.tabcontrol12LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol12JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol12JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol12JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol12JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol12JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol12JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol12MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol12MatchExciseName.Text;
                match.QuestionType = this.tabcontrol12MatchQuestionType.Text;
                match.Speech = this.tabcontrol12MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol12MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol12MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol12MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol12ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol12ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol12ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol12ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol12ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol12ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol12ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol12ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol12PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol12PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol12PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol12PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol12PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol12PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }

        private void addTabcontrol13(Trail trail)
        {

            Learning learning = new Learning();
            Judgment judgment = new Judgment();
            Match match = new Match();
            Choice choice = new Choice();
            Puzzle puzzle = new Puzzle();
            if (!this.tabcontrol13learnQuestionType.Text.Equals("不存在"))
            {
                learning.ExciseName = this.tabcontrol13LearnExciseName.Text;
                learning.QuestionType = this.tabcontrol13learnQuestionType.Text;
                learning.Question = new ImageItem();
                learning.Question.Image = this.tabcontrol13LearnImage.Text;
                learning.Question.SpeechText = this.tabcontrol13learnSound.Text;
                learning.Question.Text = this.tabcontrl13LearnKeyText.Text;

                learning.PinYing = this.tabcontrol13LearnPy.Text;
                trail.Learnings.Add(learning);
                // MessageBox.Show(strSerializeJSON);


            }
            else if (!this.tabcontrol13JudgeQuestionType.Text.Equals("不存在"))
            {
                judgment.ExciseName = this.tabcontrol13JudgeExciseName.Text;
                judgment.Speech = this.tabcontrol13JudgeSound.Text;
                judgment.QuestionType = this.tabcontrol13JudgeQuestionType.Text;
                judgment.Question = new ImageItem();

                judgment.Question.Image = this.tabcontrol13JudgeRightImage.Text;

                judgment.Distractor = new ImageItem();
                judgment.Distractor.Image = this.tabcontrol13JudgeWrongImage.Text;

                trail.Judges.Add(judgment);


                //  MessageBox.Show(judgeSerializeJSON);

            }
            else if (!this.tabcontrol13MatchQuestionType.Text.Equals("不存在"))
            {
                match.ExciseName = this.tabcontrol13MatchExciseName.Text;
                match.QuestionType = this.tabcontrol13MatchQuestionType.Text;
                match.Speech = this.tabcontrol13MatchSound.Text;
                match.Question = new ImageItem();
                match.Question.Image = this.tabcontrol13MatchQuestionImage.Text;
                match.Answer = new ImageItem();
                match.Answer.Image = this.tabcontrol13MatchAnswerImage.Text;
                match.Distractor = new ImageItem();
                match.Distractor.Image = this.tabcontrol13MatchDistraImage.Text;
                trail.Matchs.Add(match);

                //   MessageBox.Show(matchSerializeJSON);

            }
            else if (!this.tabcontrol13ChoiceQuestionType.Text.Equals("不存在"))
            {
                choice.ExciseName = this.tabcontrol13ChoiceExciseName.Text;
                choice.QuestionType = this.tabcontrol13ChoiceQuestionType.Text;
                choice.Speech = this.tabcontrol13ChoiceSound.Text;
                choice.Answer = new ImageItem();
                choice.Answer.Image = this.tabcontrol13ChoiceRightImage.Text;
                choice.Answer.SpeechText = this.tabcontrol13ChoiceRightText.Text;
                choice.Distractor = new ImageItem();
                choice.Distractor.Image = this.tabcontrol13ChoiceDistraImage.Text;
                choice.Distractor.SpeechText = this.tabcontrol13ChoiceDistraText.Text;

                trail.Choices.Add(choice);


            }
            else if (!this.tabcontrol13PuzzleQuestionType.Text.Equals("不存在"))
            {
                puzzle.ExciseName = this.tabcontrol13PuzzleExciseName.Text;
                puzzle.Speech = this.tabcontrol13PuzzleSound.Text;
                puzzle.QuestionType = this.tabcontrol13PuzzleQuestionType.Text;
                puzzle.PuzzleImage = new ImageItem();
                puzzle.PuzzleImage.Image = this.tabcontrol13PuzzleRightImage.Text;
                puzzle.Distractor = new ImageItem();
                puzzle.Distractor.Image = this.tabcontrol13PuzzleDistraImage.Text;

                trail.Puzzles.Add(puzzle);

                // MessageBox.Show(puzzleSerializeJSON);

            }

        }
        

        

       

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void tabcontrl6LearnKeyText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol5MatchQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol8LearnImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol8MatchSound_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage51_Click(object sender, EventArgs e)
        {

        }

        private void tabcontrol9MatchAnswerImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol9MatchQuestionImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol10MatchDistraImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol10ChoiceRightImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol10ChoiceRightText_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox308_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol11PuzzleQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabcontrol1ChoiceDistraText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol0PuzzleDistraImage.Text += path + ";";
           
        }

        private void button20_Click(object sender, EventArgs e)
        {
             
           
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1PuzzleRightImage.Text += path + ";";

        }

        private void button19_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1ChoiceRightImage.Text += path + ";";
            
          
        }

        private void button17_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1MatchQuestionImage.Text += path + ";";
          
          
        }

        private void button16_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1MatchAnswerImage.Text += path + ";";
         
          
        }

        private void button15_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1MatchDistraImage.Text += path + ";";
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1JudgeRightImage.Text += path + ";";
            

       
        }

        private void button13_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1JudgeWrongImage.Text += path + ";";
        
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1LearnImage.Text += path + ";";
        }
       

        private void button22_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2LearnImage.Text += path + ";";
            
        }

        private void button32_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3LearnImage.Text += path + ";";
            
        }

        private void button42_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4LearnImage.Text += path + ";";
       
        }

        private void button52_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5LearnImage.Text += path + ";";
           
        }

        private void button62_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6LearnImage.Text += path + ";";
           
        }

        private void button72_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7LearnImage.Text += path + ";";
           
        }

        private void button92_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9LearnImage.Text += path + ";";
            
        }

        private void button82_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8LearnImage.Text += path + ";";
           
        }

        private void button102_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10LearnImage.Text += path + ";";
           
         
        }

        private void button112_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11LearnImage.Text += path + ";";
          
        }

        private void button122_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12LearnImage.Text += path + ";";
        
        }

        private void button132_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12LearnImage.Text += path + ";";
         
        }

        private void button24_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2JudgeRightImage.Text += path + ";";
          
        }

        private void button34_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3JudgeRightImage.Text += path + ";";
           
        }

        private void button44_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4JudgeRightImage.Text += path + ";";
           
        }

        private void button54_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5JudgeRightImage.Text += path + ";";
           
        }

        private void button64_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6JudgeRightImage.Text += path + ";";
          
        }

        private void button74_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7JudgeRightImage.Text += path + ";";
            
        }

        private void button84_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8JudgeRightImage.Text += path + ";";
         
        }

        private void button113_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11JudgeWrongImage.Text += path + ";";
         
          
        }

        private void button103_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10JudgeWrongImage.Text += path + ";";
           
        }

        private void button104_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10JudgeRightImage.Text += path + ";";
        }

        private void button124_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12JudgeRightImage.Text += path + ";";
            
        }

        private void button134_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13JudgeRightImage.Text += path + ";";
           
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2JudgeWrongImage.Text += path + ";";
           
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3JudgeWrongImage.Text += path + ";";
          
        }

        private void button43_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4JudgeWrongImage.Text += path + ";";
            
        }

        private void button53_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5JudgeWrongImage.Text += path + ";";
           
        }

        private void button63_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6JudgeWrongImage.Text += path + ";";
            
        }

        private void button73_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7JudgeWrongImage.Text += path + ";";
           
        }

        private void button83_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8JudgeWrongImage.Text += path + ";";
          
        }

        private void button93_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9JudgeWrongImage.Text += path + ";";
          
          
        }

        private void button123_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12JudgeWrongImage.Text += path + ";";
           
        }

        private void button133_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13JudgeWrongImage.Text += path + ";";
           
      
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2MatchQuestionImage.Text += path + ";";
           
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3MatchQuestionImage.Text += path + ";";
           
           
        }

        private void button47_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4MatchQuestionImage.Text += path + ";";
           
        }

        private void button57_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5MatchQuestionImage.Text += path + ";";

       
        }

        private void button67_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6MatchQuestionImage.Text += path + ";";

        }

        private void button77_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7MatchQuestionImage.Text += path + ";";
           
        }

        private void button87_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8MatchQuestionImage.Text += path + ";";
            
        }

        private void button97_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9MatchQuestionImage.Text += path + ";";
           
        }

        private void button107_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10MatchQuestionImage.Text += path + ";";
            
        }

        private void button117_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11MatchQuestionImage.Text += path + ";";
          
        }

        private void button127_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12MatchQuestionImage.Text += path + ";";
         
        }

        private void button137_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13MatchQuestionImage.Text += path + ";";
         
        }

        private void button26_Click(object sender, EventArgs e)
        {

            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2MatchAnswerImage.Text += path + ";";
           
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3MatchAnswerImage.Text += path + ";";
           
        }

        private void button46_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4MatchAnswerImage.Text += path + ";";
           
        }

        private void button56_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5MatchAnswerImage.Text += path + ";";
           
        }

        private void button66_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6MatchAnswerImage.Text += path + ";";
           
          
        }

        private void button76_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7MatchAnswerImage.Text += path + ";";
           
        }

        private void tabPage39_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8MatchAnswerImage.Text += path + ";";
        
        }

        private void button86_Click(object sender, EventArgs e)
        {

        }

        private void button96_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9MatchAnswerImage.Text += path + ";";
            
        }

        private void button106_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10MatchAnswerImage.Text += path + ";";
          
        }

        private void button116_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11MatchAnswerImage.Text += path + ";";
          
        }

        private void button126_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12MatchAnswerImage.Text += path + ";";
          
        }

        private void button136_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13MatchAnswerImage.Text += path + ";";
           
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2MatchDistraImage.Text += path + ";";
          
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3MatchDistraImage.Text += path + ";";
           
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4MatchDistraImage.Text += path + ";";
            
        }

        private void button55_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5MatchDistraImage.Text += path + ";";
            
        }

        private void button65_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6MatchDistraImage.Text += path + ";";
         
        }

        private void button75_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7MatchDistraImage.Text += path + ";";
         
        }

        private void button95_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9MatchDistraImage.Text += path + ";";
          
        }

        private void button105_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10MatchDistraImage.Text += path + ";";
            
        }

        private void button115_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11MatchDistraImage.Text += path + ";";
          
        }

        private void button85_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8MatchDistraImage.Text += path + ";";
         
        }

        private void button125_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12MatchDistraImage.Text += path + ";";
           
        }

        private void button135_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13MatchDistraImage.Text += path + ";";
          
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2ChoiceRightImage.Text += path + ";";
           
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3ChoiceRightImage.Text += path + ";";
            
        }

        private void button49_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4ChoiceRightImage.Text += path + ";";
         
        }

        private void button59_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5ChoiceRightImage.Text += path + ";";
           
        }

        private void button69_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6ChoiceRightImage.Text += path + ";";
          
        }

        private void button79_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7ChoiceRightImage.Text += path + ";";
            
        }

        private void button89_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8ChoiceRightImage.Text += path + ";";
         
        }

        private void button99_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9ChoiceRightImage.Text += path + ";";
          
        }

        private void button109_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10ChoiceRightImage.Text += path + ";";
          
        }

        private void button119_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11ChoiceRightImage.Text += path + ";";

           
        }

        private void button129_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12ChoiceRightImage.Text += path + ";";
        
        }

        private void button139_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13ChoiceRightImage.Text += path + ";";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol1ChoiceDistraImage.Text += path + ";";
         
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2ChoiceDistraImage.Text += path + ";";
           
        }

        private void button38_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3ChoiceDistraImage.Text += path + ";";
         
        }

        private void button48_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4ChoiceDistraImage.Text += path + ";";
          
        }

        private void button58_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5ChoiceDistraImage.Text += path + ";";
          
        }

        private void button68_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6ChoiceDistraImage.Text += path + ";";
          
           
        }

        private void button78_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7ChoiceDistraImage.Text += path + ";";
           
        }

        private void button88_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8ChoiceDistraImage.Text += path + ";";
           
         
        }

        private void button98_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9ChoiceDistraImage.Text += path + ";";
          
        }

        private void button108_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10ChoiceDistraImage.Text += path + ";";
           
        }

        private void button118_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11ChoiceDistraImage.Text += path + ";";
           
        }

        private void button128_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12ChoiceDistraImage.Text += path + ";";
        
        }

        private void button138_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13ChoiceDistraImage.Text += path + ";";
           
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2PuzzleRightImage.Text += path + ";";
           
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3PuzzleRightImage.Text += path + ";";
          
        }

        private void button51_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4PuzzleRightImage.Text += path + ";";
           
        }

        private void button61_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5PuzzleRightImage.Text += path + ";";
            
        }

        private void button71_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6PuzzleRightImage.Text += path + ";";
           
        }

        private void button81_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7PuzzleRightImage.Text += path + ";";
            
        }

        private void button91_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8PuzzleRightImage.Text += path + ";";
           
        }

        private void button101_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9PuzzleRightImage.Text += path + ";";
           
        }

        private void button111_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10PuzzleRightImage.Text += path + ";";
       
        }

        private void button121_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11PuzzleRightImage.Text += path + ";";
        }
         

        private void button131_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12PuzzleRightImage.Text += path + ";";
           
        }

        private void button141_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13PuzzleRightImage.Text += path + ";";
         
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol2PuzzleDistraImage.Text += path + ";";
           
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol3PuzzleDistraImage.Text += path + ";";
            
        }

        private void button50_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol4PuzzleDistraImage.Text += path + ";";
          
        }

        private void button60_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol5PuzzleDistraImage.Text += path + ";";
          
            
        }

        private void button70_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol6PuzzleDistraImage.Text += path + ";";
          
        }

        private void button80_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol7PuzzleDistraImage.Text += path + ";";
          
        }

        private void button90_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol8PuzzleDistraImage.Text += path + ";";
          
        }

        private void button100_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9PuzzleDistraImage.Text += path + ";";
           
        }

        private void button110_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol10PuzzleDistraImage.Text += path + ";";
         
        }

        private void button120_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11PuzzleDistraImage.Text += path + ";";
          
        }

        private void button130_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol12PuzzleDistraImage.Text += path + ";";
        
        }

        private void button140_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol13PuzzleDistraImage.Text += path + ";";
            

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void button94_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol9JudgeRightImage.Text += path + ";";
        }

        private void button114_Click(object sender, EventArgs e)
        {
            string path = selectPathFromBrowser();
            if (!path.Equals(""))
                this.tabcontrol11JudgeRightImage.Text += path + ";";
        }

        private void label238_Click(object sender, EventArgs e)
        {

        }

        private void label587_Click(object sender, EventArgs e)
        {

        }

        private void tabPage82_Click(object sender, EventArgs e)
        {

        }


        
    }
}