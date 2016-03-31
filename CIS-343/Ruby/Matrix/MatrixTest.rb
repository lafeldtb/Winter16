require "minitest/autorun"
require "./Matrix"

#
# Unit tests for Matrix class (DO NOT MODIFY)
# Author: Jag Nandigam
#
class MatrixTest < Minitest::Test

  def test_initialize_1
    m1 = Matrix.new(3,4,10)
    assert_equal("10 10 10 10\n10 10 10 10\n10 10 10 10",m1.to_s().strip())
  end
    
  def test_initialize_2
    m1 = Matrix.new(3,4)
    assert_equal("0 0 0 0\n0 0 0 0\n0 0 0 0",m1.to_s().strip())
  end
      
  def test_initialize_3
    m1 = Matrix.new(3)
    assert_equal("0 0 0 0 0\n0 0 0 0 0\n0 0 0 0 0",m1.to_s().strip())
  end
  
  def test_initialize_4
    m1 = Matrix.new()
    assert_equal("0 0 0 0 0\n0 0 0 0 0\n0 0 0 0 0\n0 0 0 0 0\n0 0 0 0 0",m1.to_s().strip())
  end
    
  def test_initialize_5() 
    assert_raises(ArgumentError)  { Matrix.new(1.5,"abc",nil) }
  end
  
  def test_initialize_6() 
    assert_raises(ArgumentError)  { Matrix.new(1.5,"abc") }
  end
    
  def test_initialize_7() 
    assert_raises(ArgumentError)  { Matrix.new(1.5) }
  end
    
  def test_initialize_8() 
    assert_raises(ArgumentError)  { Matrix.new("testing with some junk") }
  end
    
  def test_initialize_9() 
    assert_raises(ArgumentError)  { Matrix.new(-3,-5,5) }
  end
    
  def test_get_1() 
    m1 = Matrix.new(3,4,5)
    assert_equal(5,m1.get(0,0))
  end
    
  def test_get_2() 
    m1 = Matrix.new(3,4,5)
    assert_equal(5,m1.get(2,3))
  end
  
  def test_get_3() 
    m1 = Matrix.new(3,4,5)
    assert_raises(ArgumentError)  { m1.get(3,4) }
  end
  
  def test_get_4() 
    m1 = Matrix.new(3,4,5)
    assert_raises(ArgumentError)  { m1.get(3.0,4.0) }
  end
    
  def test_get_5() 
    m1 = Matrix.new(3,4,5)
    assert_raises(ArgumentError)  { m1.get("first","third") }
  end
    
  def test_set_1() 
    m1 = Matrix.new(3,4)
    m1.set(0,0,5)
    assert_equal(5,m1.get(0,0))
  end
    
  def test_set_2() 
    m1 = Matrix.new(3,4)
    m1.set(2,3,5)
    assert_equal(5,m1.get(2,3))
  end

  def test_set_3() 
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError)  { m1.set(3,4,5) }
  end
  
  def test_set_4() 
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError)  { m1.set(3.0,4.0,5) }
  end
    
  def test_set_5() 
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError)  { m1.set("first","third",5.0) }
  end
        
  def test_add_1
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,4,20)
    m3 = Matrix.new(3,4,30)
    assert_equal(m3, m1.add(m2))
  end
  
  def test_add_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,5,20)
    assert_raises(IncompatibleMatricesError)  { m1.add(m2) }
  end
   
  def test_add_3
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1.add("junk") }
  end
  
  def test_subtract_1
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,4,20)
    assert_equal(m1, m2.subtract(m1))
  end
  
  def test_subtract_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,5,20)
    assert_raises(IncompatibleMatricesError)  { m1.subtract(m2) }
  end
   
  def test_subtract_3
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1.subtract("junk") }
  end
  
  def test_scalarmult_1
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,4,50)
    assert_equal(m2,m1.scalarmult(5))
  end
  
  def test_scalarmult_2
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1.scalarmult(5.0) }
  end
    
  def test_scalarmult_3
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1.scalarmult("junk") }
  end
  
  def test_multiply_1
    m1 = Matrix.new(3,3,10)
    m2 = Matrix.new(3,3,10)
    m3 = Matrix.new(3,3,300)
    assert_equal(m3,m1.multiply(m2))
  end
    
  def test_multiply_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(4,3,10)
    m3 = Matrix.new(3,3,400)
    assert_equal(m3,m1.multiply(m2))
  end
  
  def test_multiply_3
    m1 = Matrix.new(4,3,10)
    m2 = Matrix.new(3,4,10)
    m3 = Matrix.new(4,4,300)
    assert_equal(m3,m1.multiply(m2))
  end
  
  def test_multiply_4
    m1 = Matrix.new(4,3,10)
    m2 = Matrix.new(4,3,10)
    assert_raises(IncompatibleMatricesError)  { m1.multiply(m2) }
  end
  
  def test_multiply_5
    m1 = Matrix.new(4,3,10)
    assert_raises(ArgumentError)  { m1.multiply("junk") }
  end
  
  def test_transpose_1
    m1 = Matrix.new(4,3)
    m2 = Matrix.new(3,4)
    assert_equal(m2,m1.transpose())
  end
  
  def test_transpose_2
    m1 = Matrix.new(3,4,5)
    m2 = Matrix.new(4,3,5)
    assert_equal(m2,m1.transpose())
  end
  
  def test_transpose_3
    m1 = Matrix.new(4,4,5)
    assert_equal(m1,m1.transpose())
  end
  
  def test_plus_1
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,4,20)
    m3 = Matrix.new(3,4,30)
    assert_equal(m3, m1 + m2)
  end
  
  def test_plus_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,5,20)
    assert_raises(IncompatibleMatricesError)  { m1 + m2 }
  end
   
  def test_plus_3
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1 + "junk" }
  end
  
  def test_minus_1
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,4,20)
    assert_equal(m1, m2 - m1)
  end
  
  def test_minus_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(3,5,20)
    assert_raises(IncompatibleMatricesError)  { m1 - m2 }
  end
   
  def test_minus_3
    m1 = Matrix.new(3,4,10)
    assert_raises(ArgumentError)  { m1 - "junk" }
  end
  
  def test_times_1
    m1 = Matrix.new(3,3,10)
    m2 = Matrix.new(3,3,10)
    m3 = Matrix.new(3,3,300)
    assert_equal(m3,m1 * m2)
  end
    
  def test_times_2
    m1 = Matrix.new(3,4,10)
    m2 = Matrix.new(4,3,10)
    m3 = Matrix.new(3,3,400)
    assert_equal(m3,m1 * m2)
  end
  
  def test_times_3
    m1 = Matrix.new(4,3,10)
    m2 = Matrix.new(3,4,10)
    m3 = Matrix.new(4,4,300)
    assert_equal(m3,m1 * m2)
  end
  
  def test_times_4
    m1 = Matrix.new(4,3,10)
    m2 = Matrix.new(4,3,10)
    assert_raises(IncompatibleMatricesError)  { m1 * m2 }
  end
  
  def test_times_5
    m1 = Matrix.new(4,3,10)
    assert_raises(ArgumentError)  { m1 * "junk" }
  end
  
  def test_identity_1
    m1 = Matrix.identity(3)
    assert_equal("1 0 0\n0 1 0\n0 0 1",m1.to_s().strip())
  end
  
  def test_identity_2
    m1 = Matrix.identity(1)
    assert_equal("1",m1.to_s().strip())
  end
  
  def test_identity_3
    assert_raises(ArgumentError) { Matrix.identity(0) }
  end
  
  def test_identity_4
    assert_raises(ArgumentError) { Matrix.identity("junk") }
  end
  
  def test_identity_5
    assert_raises(ArgumentError) { Matrix.identity(false) }
  end
  
  def test_fill_1
    m1 = Matrix.new(3,4)
    m1.fill(5)
    assert_equal("5 5 5 5\n5 5 5 5\n5 5 5 5",m1.to_s().strip())
  end
  
  def test_fill_2
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError) { m1.fill(5.0) }
  end
  
  def test_fill_3
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError) { m1.fill("junk") }
  end
  
  def test_fill_4
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError) { m1.fill(1..5) }
  end
  
  def test_fill_5
    m1 = Matrix.new(3,4)
    assert_raises(ArgumentError) { m1.fill(false) }
  end
  
  def test_clone_1
    m1 = Matrix.new(3,4,5)
    m2 = m1.clone()
    assert_equal(m1,m2)
    refute_same(m1,m2)
    #assert_not_same(m1,m2)
  end
  
  def test_clone_2
    m1 = Matrix.new(3,4)
    m2 = m1.clone()
    assert_equal(m1,m2)
    refute_same(m1,m2)
    #assert_not_same(m1,m2)
  end
  
  def test_equalop_1
    m1 = Matrix.new(3,4,5)
    m2 = Matrix.new(3,4,5)
    assert_equal(true,m1 == m2)
  end
  
  def test_equalop_2
    m1 = Matrix.new(3,4,5)
    m2 = Matrix.new(3,4,10)
    assert_equal(false,m1 == m2)
  end
  
  def test_equalop_3
    m1 = Matrix.new(3,4,5)
    m2 = Matrix.new(4,3,5)
    assert_equal(false,m1 == m2)
  end
   
  def test_equalop_4
    m1 = Matrix.new(3,4,5)
    assert_equal(true,m1 == m1)
  end
   
  def test_equalop_5
    m1 = Matrix.new(3,4,5)
    assert_equal(false,m1 == "junk")
  end
       
  def test_each_1()
    m1 = Matrix.new(2,2)
    m1.set(0,0,5)
    m1.set(0,1,10)
    m1.set(1,0,15)
    m1.set(1,1,20)
    str = ""
    m1.each() do |i,j,val|
      str << i.to_s + "," + j.to_s + "," + val.to_s + ";"
    end
    assert_equal("0,0,5;0,1,10;1,0,15;1,1,20;",str)
  end
  
  def test_each_2()
    m1 = Matrix.new(3,4,5)
    str = ""
    m1.each() do |i,j,val|
      str << i.to_s + "," + j.to_s + "," + val.to_s + ";"
    end
    assert_equal("0,0,5;0,1,5;0,2,5;0,3,5;1,0,5;1,1,5;1,2,5;1,3,5;2,0,5;2,1,5;2,2,5;2,3,5;",str)
  end
                    
end