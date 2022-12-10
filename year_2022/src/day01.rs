use std::fs;

pub fn day_one() {
    let puzzle = fs::read_to_string("./puzzles/01.txt").expect("Could not read file");
    let mut calories: Vec<i32> = Vec::new();
    let mut temp = 0;

    for line in puzzle.lines() {
        if line != "" {
            temp += line.parse::<i32>().unwrap();
        } else {
            calories.push(temp);
            temp = 0;
        }
    }

    calories.sort();
    calories.reverse();

    println!("DAY 01 - 1 => {}", calories[0]);
    println!("DAY 01 - 2 => {}", (calories[0] + calories[1] + calories[2] ));
}