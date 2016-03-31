#
#  Minesweeper game
#
#  Author(s): Mattie Phillips & Ben LaFeldt
#

#
# module that defines global constants
#
module Constants
  WON = 0
  LOST = 1
  INPROGRESS = 2
  BOARD_SIZE_MIN = 5
  BOARD_SIZE_MAX = 15
  PCT_MINES_MIN = 10
  PCT_MINES_MAX = 70
end

#
# Cell class represents a cell on the minesweeper board
#
class Cell
  
  attr_accessor :is_mine, :nbr_mines, :visible
  
  def initialize(nbr_mines,is_mine,visible)
    self.nbr_mines=(nbr_mines)
    self.is_mine=(is_mine)
    self.visible=(visible)
  end
  
  def to_s
    "#@is_mine #@nbr_mines #@visible"
  end
end

#
# Minesweeper class represents the game board and contains game logic
#
class Minesweeper
  
  # initializes a Minesweeper object
  def initialize(board_size,percent_mines)
    @board_size = board_size
    @nbr_mines = (board_size * board_size * (percent_mines/100.0)).to_i
    
    # setup a 2-dimensional array of Cell objects
    @board = Array.new(board_size)
    @board.fill { |i| Array.new(board_size) }
    for i in 0...board_size
      for j in 0...board_size
        @board[i][j] = Cell.new(0,false,false)
      end
    end
    
    place_mines_on_board()
    fill_in_minecount_for_non_mine_cells()
  end
  
  # places mines randomly on the board
  def place_mines_on_board
    nbr_left = @nbr_mines
	temp_board = @board
	while nbr_left > 0
		row = rand(0...@board_size)
		col = rand(0...@board_size)
		if !temp_board[row][col].is_mine
			temp_board[row][col].is_mine = true
			nbr_left -= 1
		end
	end
	temp_board
  end
  
  # for each non-mine cell on the board, set @nbr_mines of each Cell on the board
  # to the number of mines in the immediate neighborhood.
  def fill_in_minecount_for_non_mine_cells
	temp_board = @board
	row = 0
	while row < @board_size
		col = 0
			while col < @board_size
				if !temp_board[row][col].is_mine
					temp_board[row][col].nbr_mines = get_nbr_neighbor_mines(row,col)
				end
			col += 1
			end
	row += 1
	end
	temp_board
  end
    
  # processes cell selection by user during the game
  # returns Constants::WON, Constants::LOST, or Constants::INPROGRESS
  def select_cell(row,col)
	board = @board
	if board[row][col].nbr_mines == 0
		set_all_neighbor_cells_visible(row,col)
	end
	board[row][col].visible = true
	if board[row][col].is_mine
		return Constants::LOST
	elsif nbr_visible_cells() == (@board_size*@board_size)-@nbr_mines
		return Constants::WON
	end

	return Constants::INPROGRESS
  end
  
  # returns the number of mines in the immediate neighborhood of a cell
  # at location (row,col) on the board.
  def get_nbr_neighbor_mines(row,col)
	count = 0
	currentCol = col-1
	while currentCol<col+2
		if currentCol >= 0 and currentCol < @board_size
			currentRow = row-1
			while currentRow<row+2
				if currentRow < @board_size and currentRow >= 0
					if @board[currentRow][currentCol].is_mine
						count+=1
					end
				end
			currentRow += 1
			end
		end
	currentCol+=1
	end
	count
  end
  
  # returns the number of cells that are currently visible on the board
  def nbr_visible_cells
	count = 0
	row = 0
	while row < @board_size
		col = 0
		while col < @board_size
			if @board[row][col].visible
				count += 1
			end
		col += 1
		end
	row += 1
	end
	count
  end
  
  # if the mine count of a cell at location (row,col) is zero, then make
  # the cells ONLY in the immediate neighborhood visible.
  def set_immediate_neighbor_cells_visible(row,col)
    
  end
  
  # if the mine count of a cell at location (row,col) is zero, then make 
  # the cells in the immediate neighborhood visible and repeat this
  # process for each of the cells in this set of cells that have a mine
  # count of zero, and so on.
  def set_all_neighbor_cells_visible(row,col)
	board = @board
	if !board[row][col].visible 
		board[row][col].visible = true
		if board[row][col].nbr_mines == 0
			if row < @board_size-1
				set_all_neighbor_cells_visible(row+1,col)
			end
			if row > 0
				set_all_neighbor_cells_visible(row-1,col)
			end
			if col < @board_size-1
				set_all_neighbor_cells_visible(row,col+1)
			end
			if col > 0
				set_all_neighbor_cells_visible(row,col-1)
			end
		end
	end
	board
  end
  
  # returns a string representation of the board
  def to_s(display_mines=false)
    str = ""
    for i in 0...@board_size
      str << (i == 0 ? sprintf("%6d",i+1) : sprintf("%3d",i+1))
    end
    str << "\n"
    
    for i in 0...@board_size
      str << sprintf("%3d",i+1)
      for j in 0...@board_size
        if @board[i][j].visible
          str << (@board[i][j].is_mine ? sprintf(" \x1b[30;41m*\x1b[0m") : sprintf("%3d\x1b[0m", @board[i][j].nbr_mines))
        else
          str << (display_mines && @board[i][j].is_mine ? sprintf("  \x1b[30;41m*\x1b[0m") : sprintf("  ?"))
        end
      end
      str << "\n"
    end
    
    str
  end
  
  # make these methods private
  private :place_mines_on_board, :fill_in_minecount_for_non_mine_cells,
        :get_nbr_neighbor_mines, :nbr_visible_cells,
        :set_immediate_neighbor_cells_visible, :set_all_neighbor_cells_visible

end

#
# main method that provides the user interface to the game
#
def main
  print "!!!!!WELCOME TO THE MINESWEEPER GAME!!!!!\n\n"
  display_mines = false
  game_state = Constants::INPROGRESS
  
  board_size = get_board_size()
  percent_mines = get_percent_mines()
  board = Minesweeper.new(board_size,percent_mines)
  puts board.to_s(display_mines)
  
  while true do
    print "Enter command (m/M for menu): "
    command = STDIN.gets.strip
    case command
      when 'm' || 'M'
        display_menu()
        
      when 'c' || 'C'
        row = 0
        col = 0
        while row < 1 || row > board_size || col < 1 || col > board_size do
          print "Enter row and column of cell: "
          tokens = STDIN.gets.strip.split(' ')
          row = tokens[0].to_i
          col = tokens[1].to_i
          if row < 1 || row > board_size || col < 1 || col > board_size
            puts "Invalid row or column values. Try again."
          end
        end
        game_state = board.select_cell(row-1,col-1)
        puts board.to_s(display_mines)
        
      when 's' || 'S'
        display_mines = true
        puts board.to_s(display_mines)
        
      when 'h' || 'H'
        display_mines = false
        puts board.to_s(display_mines)
        
      when 'b' || 'B'
        puts board.to_s(display_mines)
        
      when 'q' || 'Q'
        puts "Bye."
        return
        
      else
        puts "Invalid command. Try again."
    end # end case
    
    if game_state == Constants::WON
      puts "You found all the mines. Congratulations. Bye."
      return
    elsif game_state == Constants::LOST
      puts "Oops. Sorry, you landed on a mine. Bye"
      return
    end
  end   # end while
  
end

#
# Displays command menu
#
def display_menu
  puts "List of available commands:"
  puts "   Show Mines: s/S"
  puts "   Hide Mines: h/H"
  puts "   Select Cell: c/C"
  puts "   Display Board: b/B"
  puts "   Display Menu: m/M"
  puts "   Quit: q/Q"
end

#
# Prompts the user for board size, reads and validates the input
# entered, and returns the integer if it is within valid range.
# repeats this in a loop until the user enters a valid value.
#
def get_board_size
  size = 0
  while size < Constants::BOARD_SIZE_MIN || size > Constants::BOARD_SIZE_MAX do
    print "Enter board size (#{Constants::BOARD_SIZE_MIN} .. #{Constants::BOARD_SIZE_MAX}): "
    size = STDIN.gets.strip.to_i
    if (size < Constants::BOARD_SIZE_MIN || size > Constants::BOARD_SIZE_MAX) 
      puts "Invalid board size. Try again."
    end
  end
  size
end

#
# Prompts the user for percentage of mines to place on the board,
# reads and validates the input entered, and returns the integer if it
# is within valid range. repeats this in a loop until the user enters
# a valid value for board size.
#
def get_percent_mines
  percent_mines = 0
  while percent_mines < Constants::PCT_MINES_MIN || percent_mines > Constants::PCT_MINES_MAX do
    print "Enter percentage of mines on the board (#{Constants::PCT_MINES_MIN} .. #{Constants::PCT_MINES_MAX}): "
    percent_mines = STDIN.gets.strip.to_i
    if (percent_mines < Constants::PCT_MINES_MIN || percent_mines > Constants::PCT_MINES_MAX)
      puts "Invalid value for percentage. Try again."
    end
  end
  percent_mines
end
 
#
# invoke main
#
main()
