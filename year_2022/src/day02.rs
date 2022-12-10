use std::fs;
use std::str::FromStr;

#[derive(Clone, Copy, PartialEq)]
enum GameChoice {
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

impl FromStr for GameChoice {
    type Err = String;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        match s.to_uppercase().as_str() {
            "A" | "X" => Ok(Self::Rock),
            "B" | "Y" => Ok(Self::Paper),
            "C" | "Z" => Ok(Self::Scissors),
            _ => Err(format!("No game choice found: {s}; expected ABC/XYZ")),
        }
    }
}

enum GameResult {
    Win = 6,
    Draw = 3,
    Lose = 0
}

impl GameResult {
    pub fn check(p1: GameChoice, p2: GameChoice) -> GameResult {
        let to_match = format!("{}{}", p1 as i32, p2 as i32);
        match to_match.as_str() {
            "11" | "22" | "33"  => {
                GameResult::Draw
            }
            "12" | "23" | "31"  => {
                GameResult::Win
            }
            _ => {
                GameResult::Lose
            }
        }
    }

    pub fn get(result: GameResult, p1: GameChoice) -> GameChoice {
        return match result {
            GameResult::Win => {
                match p1 {
                    GameChoice::Rock => GameChoice::Paper,
                    GameChoice::Paper => GameChoice::Scissors,
                    GameChoice::Scissors=> GameChoice::Rock
                }
            }
            GameResult::Lose => {
                match p1 {
                    GameChoice::Rock => GameChoice::Scissors,
                    GameChoice::Paper => GameChoice::Rock,
                    GameChoice::Scissors=> GameChoice::Paper
                }
            }
            GameResult::Draw => {
                p1
            }
        }
    }
}

impl FromStr for GameResult {
    type Err = String;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        match s.to_uppercase().as_str() {
            "X" => Ok(Self::Lose),
            "Y" => Ok(Self::Draw),
            "Z" => Ok(Self::Win),
            _ => Err(format!("No game result found: {s}; expected XYZ")),
        }
    }
}

pub fn day_two() {
    let puzzle = fs::read_to_string("./puzzles/02.txt").expect("Could not read file");
    let mut part_one = 0;
    let mut part_two = 0;

    for game in puzzle.lines() {
        let chooses = game.split(" ").collect::<Vec<&str>>();
        let p1 = GameChoice::from_str(chooses[0]).expect("try get game choice");
        let p2 = GameChoice::from_str(chooses[1]).expect("try get game choice");

        part_one += result_part_one(p1, p2);
        part_two += result_part_two(p1, chooses[1]);
    }

    println!("DAY 2 - 1 => {}", part_one);
    println!("DAY 2 - 2 => {}", part_two);
}

fn result_part_one(p1: GameChoice, p2: GameChoice) -> i32 {
    let base_points = p2 as i32;
    let result = GameResult::check(p1, p2);

    return base_points + (result as i32);
}

fn result_part_two(p1: GameChoice, p2_str: &str) -> i32 {
    let outcome = GameResult::from_str(p2_str).expect("try get game result");
    let p2: GameChoice = GameResult::get(outcome, p1);
    let base_points = p2 as i32;
    let result = GameResult::check(p1, p2);

    return base_points + (result as i32);
}