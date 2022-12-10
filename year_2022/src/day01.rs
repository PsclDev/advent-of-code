use std::fs;

pub fn day_one() {
    let puzzle = fs::read_to_string("./puzzles/01.txt").expect("Could not read file");
    let mut calories: Vec<i32> = Vec::new();
    let mut temp = 0;

    for split in puzzle.lines() {
        if split != "" {
            temp += split.parse::<i32>().unwrap();
        } else {
            calories.push(temp);
            temp = 0;
        }
    }

    calories.sort();
    calories.reverse();

    println!("DAY 1 - 1 => {}", calories[0]);
    println!("DAY 1 - 2 => {}", (calories[0] + calories[1] + calories[2] ));
}