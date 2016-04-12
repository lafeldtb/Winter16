#
#  Class that represents a Matrix and implements operations on matrices.
#
#  Author(s): Ben LaFeldt and Mattie Phillips
#
class Matrix

  # create getter methods for instance variables @rows and @columns
  attr_reader  :rows, :columns

  # create setter methods for instance variables @rows and @columns
  attr_writer  :rows, :columns

  # make setter methods for @rows and @columns private
  private :rows=, :columns=
  # method that initializes a newly allocated Matrix object
  # use instance variable named @data (an array) to hold matrix elements
  # raise ArgumentError exception if any of the following is true:
  #     parameters rows or columns or val is not of type Fixnum
  #     value of rows or columns is <= 0
  def initialize(rows=5, columns=5, val=0)
    raise ArgumentError.new("Argument is not a Fixnum object") unless rows.instance_of?(Fixnum) and columns.instance_of?(Fixnum) and val.instance_of?(Fixnum)
    raise ArgumentError.new("Rows or columns are <= 0") unless rows >= 0 and columns >=0
    @rows = rows
    @columns = columns
    @board = Array.new(rows) {Array.new(columns, val)}
  end

  # method that returns matrix element at location (i,j)
  # NOTE: row and column values are zero-index based
  # raise ArgumentError exception if any of the following is true:
  #     parameters i or j is not of type Fixnum
  #     value of i or j is outside the bounds of Matrix
  def get(i, j)
    raise ArgumentError.new("Argument is not a Fixnum object") unless i.instance_of?(Fixnum) and j.instance_of?(Fixnum)
    raise ArgumentError.new("Rows or columns are outside the Matrix bounds") unless i>=0 and i<@rows and j>=0 and j<@columns
    return @board[i][j]
  end

  # method to set the value of matrix element at location (i,j) to value of parameter val
  # NOTE: row and column values are zero-index based
  # raise ArgumentError exception if any of the following is true:
  #     parameters i or j or val is not of type Fixnum
  #     the value of i or j is outside the bounds of Matrix
  def set(i, j, val)
    raise ArgumentError.new("Argument is not a Fixnum object") unless i.instance_of?(Fixnum) and j.instance_of?(Fixnum) and val.instance_of?(Fixnum)
    raise ArgumentError.new("Rows or columns are outside the Matrix bounds") unless i>=0 and i<@rows and j>=0 and j<@columns
    @board[i][j] = val
  end

  # method that returns a new matrix object that is the sum of this and parameter matrices.
  # raise ArgumentError exception if the parameter m is not of type Matrix
  # raise IncompatibleMatricesError exception if the matrices are not compatible for addition operation
  def add(m)
    raise ArgumentError.new("Argument is not a Martix object") unless m.instance_of?(Matrix)
    raise IncompatibleMatricesError.new("Matrices are incompatible") unless @rows == m.rows and @columns == m.columns
    @temp = Matrix.new(@rows, @columns, 0)
    m.each do |i, j, val|
      @temp.set(i ,j, (@board[i][j] + val))
    end
    return @temp
  end

  # method that returns a new matrix object that is the difference of this and parameter matrices
  # raise ArgumentError exception if the parameter m is not of type Matrix
  # raise IncompatibleMatricesError exception if the matrices are not compatible for subtraction operation
  def subtract(m)
    raise ArgumentError.new("Argument is not a Matrix object") unless m.instance_of?(Matrix)
    raise IncompatibleMatricesError.new("Matrices are incompatible") unless @rows == m.rows and @columns == m.columns
    @temp = Matrix.new(@rows, @columns, 0)
    m.each do |i, j, val|
      @temp.set(i,j, (@board[i][j] - val))
    end
    return @temp
  end

  # method that returns a new matrix object that is a scalar multiple of source matrix object
  # raise ArgumentError exception if the parameter k is not of type Fixnum
  def scalarmult(k)
    raise ArgumentError.new("Argument is not a Fixnum object") unless k.instance_of?(Fixnum)
    @temp = Matrix.new(@rows, @columns, 0)
    for i in 0...@rows
      for j in 0...@columns
        @temp.set(i,j,(@board[i][j] * k))
      end
    end
    @temp
  end

  # method that returns a new matrix object that is the product of this and parameter matrices
  # raise ArgumentError exception if the parameter m is not of type Matrix
  # raise IncompatibleMatricesError exception if the matrices are not compatible for multiplication operation
  def multiply(m)
    raise ArgumentError.new("Argument is not a Matrix object") unless m.instance_of?(Matrix)
    raise IncompatibleMatricesError.new("Matrices are not compatible for multiplication operation") unless @columns == m.rows
    @temp = Matrix.new(@rows, m.columns, 0)
    for i in 0...@rows
      for j in 0...m.columns
        val = 0
        for index in 0...@columns
          val += @board[i][index]*m.get(index, j)
        end
        @temp.set(i,j, val)
      end
    end
    return @temp
  end

  # method that returns a new matrix object that is the transpose of the source matrix
  def transpose
    @temp = Matrix.new(@columns, @rows, 0)
    for i in 0...@rows
      for j in 0...@columns
        val = @board[i][j]
        @temp.set(j, i, val)
      end
    end
    return @temp
  end

  # overload + for matrix addition
  def +(m)
    add(m)
  end

  # overload - for matrix subtraction
  def -(m)
    subtract(m)
  end

  # overload * for matrix multiplication
  def *(m)
    multiply(m)
  end

  # class method that returns an identity matrix with size number of rows and columns
  # raise ArgumentError exception if any of the following is true:
  #     parameter size is not of type Fixnum
  #     the value of size <= 0
  def Matrix.identity(size)
    raise ArgumentError.new("Argument is not a Fixnum object") unless size.instance_of?(Fixnum) 
    raise ArgumentError.new("Rows or columns are >= 0") unless size > 0
    @temp =  Matrix.new(size, size)
    for i in 0...size
      for k in 0...size
        if i == k
          @temp.set(i,k, 1)
        end
      end
    end
    return @temp
  end

  # method that sets every element in the matrix to value of parameter val
  # raise ArgumentError exception if val is not of type Fixnum
  # hint: use fill() method of Array to fill the matrix
  def fill(val)
    raise ArgumentError.new("Argument is not a Fixnum object") unless val.instance_of?(Fixnum)
    for i in 0...@rows
      for j in 0...@columns
        @board[i][j] = val
      end
    end
  end

  # method that return a deep copy/clone of this matrix object
  def clone    
    @temp = Matrix.new(@rows, @columns, 0)
    @temp.each do |i, j, val|
      @temp.set(i,j, @board[i][j])
    end
    return @temp
  end

  # method that returns true if this matrix object and the parameter matrix object are equal
  # (i.e., have the same number of rows, columns, and corresponding values in the two
  # matrices are equal). Otherwise, it returns false.
  # returns false if the parameter m is not of type Matrix
  def ==(m)
    return false unless m.instance_of?(Matrix)
    return false unless m.rows == @rows
    return false unless m.columns == @columns
    m.each do |i, j, val|
      return false unless @board[i][j] == val
    end
    return true
  end

  # method that returns a string representation of matrix data in table (row x col) format
  def to_s
    content = ""
    @board.each do |row|
      row.each do |col|
        content += col.to_s + " "
      end
      content = content.strip
      content += "\n"
    end
   return content.chomp("\n")
  end

  # method that for each element in the matrix yields with information
  # on row, column, and data value at location (i,j)
  def each
    for i in 0...@rows
      for j in 0...@columns
        yield i, j, @board[i][j]
      end
    end
  end
  
end

#
# Custom exception class IncompatibleMatricesError
#
class IncompatibleMatricesError < Exception
  def initialize(msg)
    super msg
  end
end

#
#  main test driver
#
def main
  m1 = Matrix.new(3,4,10)
  m2 = Matrix.new(3,4,20)
  m3 = Matrix.new(4,5,30)
  m4 = Matrix.new(3,5,40)

  puts(m1)
  puts(m2)
  puts(m3)
  puts(m4)

  puts(m1.add(m2))

  puts(m1.subtract(m2))

  puts(m1.multiply(m3))

  puts(m2.scalarmult(5))

  puts(Matrix.identity(5))

  puts(m1 + m2)

  puts(m2 - m1)

  puts(m1 * m3)

  puts(m1 + m2 - m1)

  puts(m4 + m2 * m3)

  puts(m1.clone())

  puts(m1.transpose())

  puts("Are matrices equal? #{m1 == m2}")

  puts("Are matrices equal? #{m1 == m3}")

  puts("Are matrices equal? #{m1 == m1}")

  m1.each { |i, j, val|
    puts("(#{i},#{j},#{val})")
  }

  begin
    m1.get(4,4)
  rescue ArgumentError => exp
    puts("#{exp.message} - get failed\n")
  end

  begin
    m1.set(4,5,10)
  rescue ArgumentError => exp
    puts("#{exp.message} - set failed\n")
  end

  begin
    m1.add(m3)
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - add failed\n")
  end

  begin
    m2.subtract(m3)
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - subtract failed\n")
  end

  begin
    m1.multiply(m2)
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - multiply failed\n")
  end

  begin
    m1 + m3
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - add failed\n")
  end

  begin
    m2 - m3
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - subtract failed\n")
  end

  begin
    m1 * m2
  rescue IncompatibleMatricesError => exp
    puts("#{exp.message} - multiply failed\n")
  end

end

# uncomment the following line to run the main() method
# main()
