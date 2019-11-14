def count_playable_cards (hand,pile,pile_color):
"""
This function only takes the hand list the pile and the piles color
It returns the amount of playable cards we have sorted by their type
and a list of all the playable cards
"""
    how_many_TAKI = 0
    #how many playable + cards do we have
    how_many_+ = 0
    #how many playable change direction cards do we have
    how_many_CHADIR = 0
    #how many playable stop or +2 cards do we have
    how_many_STOP_or_+2 = 0
    #how many change color cards do we have
    how_many_CHCOL = 0
    #how many regular cards (1-9) do we have
    how_many_regular_num = 0
    #a list of all the cards we can play
    cards_that_can_play = []
    
    for card in hand:
    if card["color"] == pile_color or card["value"] == pile["value"] or card["color"] == "ALL":
        if card["value"] == "TAKI":
            how_many_TAKI += 1
        else:
            if card["value"] == "+":
                how_many_+ += 1
            else:
                if card["value"] == "CHADIR":
                    how_many_CHADIR += 1
                else:
                    if card["value"] == "STOP" or card["value"] == "+2":
                        how_many_STOP_or_+2 += 1 
                    else:
                        if card["value"] == "chcol":
                            how_many_CHCOL += 1
                        else:
                            how_many_regular_num += 1
        cards_that_can_play.append(card)
    return cards_that_can_play,how_many_TAKI, how_many_+, how_many_CHADIR, how_many_STOP_or_+2, how_many_CHCOL, how_many_regular_num
    

def find_correct_card(cards_that_can_play, wanted_card_values):
"""
This function requires a list of all the playable cards and the values
of the cards that we want to find in the cards that can play list
and returns a list of tuples (the card,his place in the list)
"""
    optional_cards = []
    count = 0
    for card in cards_that_can_play:
        for wanted_card_value in wanted_card_values:
            if card["value"] == wanted_card_value:
                optional_cards.append((card,count))
        count += 1
    return optional_cards

def the_color_with_the_largest_amount_of_cards(hand):
    cards_color_count = {"red": 0"blue": 0"green": 0"yellow": 0}
    for card in hand:
        cards_color_counter[card["color"]] += 1
    if cards_color_count["red"] >= cards_color_count["blue"] and cards_color_count["red"] >= cards_color_count["yellow"] and cards_color_count["red"] >= cards_color_count["green"]:
        return "red"
    else:
        if cards_color_count["blue"] >= cards_color_count["red"] and cards_color_count["blue"] >= cards_color_count["yellow"] and cards_color_count["blue"] >= cards_color_count["green"]:
            return "blue"
        else:
            if cards_color_count["yellow"] >= cards_color_count["red"] and cards_color_count["yellow"] >= cards_color_count["blue"] and cards_color_count["yellow"] >= cards_color_count["green"]:
                return "yellow"
            else:
                return "green"
                                      
def plain_strat (hand, how_many_TAKI, how_many_+, how_many_CHADIR, how_many_STOP_or_+2, how_many_CHCOL, how_many_regular_num, cards_that_can_play):
"""
This function requires the amount of playable cards sorted by types a list of the cards we have
and a list of the playable cards
"""
    cards_playing = []
    changed_color = ""
    take_card = False
                                      
    if how_many_TAKI > 0:
        for card in cards_that_can_play:
            if card["value"] == "TAKI":
                cards_playing.append(card)
        for card in cards_that_can_play:
            if card["value"] != "TAKI" and card["color"] != "ALL":
                cards_playing.append(card)
    else:
        if how_many_+ > 0:
            if how_many_regular_num > 0:
                optional_cards = find_correct_card(cards_that_can_play,["+"])
                for card in optional_cards:
                    cards_playing.append(card)
                optional_cards = find_correct_card(cards_that_can_play,["1", "2", "3", "4", "5", "6", "7", "8", "9"])
                cards_playing.append(optional_cards[0])
            else:
                if how_many_CHADIR > 0:
                    optional_cards = find_correct_card(cards_that_can_play,["+"])
                    for card in optional_cards:
                        cards_playing.append(card)
                    optional_cards = find_correct_card(cards_that_can_play,["CHADIR"])
                    cards_playing.append(optional_cards[0])
                else:
                    if how_many_STOP_or_+2 > 0:
                        optional_cards = find_correct_card(cards_that_can_play,["+"])
                        for card in optional_cards:
                            cards_playing.append(card)
                        optional_cards = find_correct_card(cards_that_can_play,["STOP", "+2"])
                        cards_playing.append(optional_cards[0])
                    else:
                        if how_many_CHCOL > 0:
                            optional_cards = find_correct_card(cards_that_can_play,["+"])
                            for card in optional_cards:
                            cards_playing.append(card)
                            optional_cards = find_correct_card(cards_that_can_play,["CHCOL"])
                            cards_playing.append(optional_cards[0])
                            changed_color = the_color_with_the_largest_amount_of_cards(hand)
                        else:
                            take_card = True
        else:
            if how_many_regular_num > 0:
                optional_cards = find_correct_card(cards_that_can_play,["1", "2", "3", "4", "5", "6", "7", "8", "9"])
                cards_playing.append(optional_cards[0])
            else:
                if how_many_CHADIR > 0:
                    optional_cards = find_correct_card(cards_that_can_play,["CHDIR"])
                    cards_playing.append(optional_cards[0])
                else:
                    if how_many_CHCOL > 0:
                        optional_cards = find_correct_card(cards_that_can_play,["CHCOL"])
                        cards_playing.append(optional_cards[0])
                        changed_color = the_color_with_the_largest_amount_of_cards(hand)
                    else:
                       take_card = True
    return cards_playing, changed_color, take_card


def turn (hand, after_me, before_me, pile, pile_color)
"""
This function require our hand, the amount of cards the player before
us have, the amount of cards the player before us have the pile and the piles color

The function returns a list [a list of cards that we need to play this turn,
a boolian variable that that indicates if we need to take a card,
a string that holds the color which we want to change to (this string will be empty if we arent playing a change color card)]

*this is the main function of the bot*
"""
    #a list of the cards that we need to play this turn
    cards_playing = []
    #a flag that turns true if we cant play any cards/dont have any +2
    take_card = False
    #if we use a change color card this variable will hold the color that we want to change to
    changed_color = ""
    
    cards_that_can_play,how_many_TAKI, how_many_+, how_many_CHADIR, how_many_STOP_or_+2, how_many_CHCOL, how_many_regular_num = count_playable_cards(hand)
                                 
    #if someone used +2 on us                               
    if pile["value"] == "+2":
        if how_many_STOP_or_+2 > 0:
            for card in cards_that_can_play:
                if card["value"] == "+2":
                    cards_playing.append(card)
                    break
        else:
            take_card = True
    """
    Strategy:
    the strategy can be found in taki.docs as a well explained flowchart
    """
    else:
        if how_many_+ > 0  or how_many_CHADIR > 0  or  how_many_STOP_or_+2 > 0 or  how_many_CHCOL > 0 or  how_many_regular_num > 0 or how_many_TAKI > 0:      
            if before_me < 4:
                if how_many_STOP_or_+2 > 0:
                    optional_cards = find_correct_card(cards_that_can_play,["+2", "STOP"])
                    cards_playing.append(optional_cards[0])
                else:
                    if how_many_CHADIR > 0 and before_me > after_me:
                        optional_cards = find_correct_card(cards_that_can_play,["CHDIR"])
                        cards_playing.append(optional_cards[0])
                    else:
                        cards_playing, changed_color, take_card = plain_strat (hand, how_many_TAKI, how_many_+, how_many_CHADIR, how_many_STOP_or_+2, how_many_CHCOL, how_many_regular_num, cards_that_can_play)    
            else:
                cards_playing, changed_color, take_card = plain_strat (hand, how_many_TAKI, how_many_+, how_many_CHADIR, how_many_STOP_or_+2, how_many_CHCOL, how_many_regular_num, cards_that_can_play)
        else:
           take_card = True
    return [cards_playing,take_card,changed_color]

                
                                      
            
                                    
