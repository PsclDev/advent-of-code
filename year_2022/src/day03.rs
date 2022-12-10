use std::fs;

pub fn day_three() {
    let puzzle = fs::read_to_string("./puzzles/03.txt").expect("Could not read file");
    let mut prio_one = 0;

    for line in puzzle.lines() {
        let half = line.len() / 2;
        let first: String = line.chars().take(half).collect();
        let second: String = line.chars().skip(half).take(half).collect();

        for cha in first.chars() {
            if second.contains(cha) {
                prio_one += get_prio(cha);
                break;
            }
        }
    }

    let mut group: [&str; 3] = ["", "", ""];
    let mut count = 0;
    let mut prio_two = 0;

    for line in puzzle.lines() {
        if count <= 2 {
            group[count] = line;
            count += 1;
        } else {
            prio_two += get_prio_of_group(group);
            group[0] = line;
            count = 1;
        }
    }
    prio_two += get_prio_of_group(group);

    println!("DAY 03 - 1 => {}", prio_one);
    println!("DAY 03 - 2 => {}", prio_two);
}

fn get_prio(cha: char) -> i32 {
    let lowercase_alphabet: [char; 26] = ['a', 'b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'];
    let uppercase_alphabet: [char; 26] = ['A', 'B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'];

    return if cha.is_uppercase() {
        27 + uppercase_alphabet.iter().position(|&r| r == cha).unwrap()
    } else {
        1 + lowercase_alphabet.iter().position(|&r| r == cha).unwrap()
    } as i32
}

fn get_prio_of_group(group: [&str; 3]) -> i32 {
    for cha in group[0].chars() {
        if group[1].contains(cha) && group[2].contains(cha) {
            return get_prio(cha);
        }
    }
    return 0;
}