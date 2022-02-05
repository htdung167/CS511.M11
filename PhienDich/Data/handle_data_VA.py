import sqlite3 as lite
import re


f = open("./vietanh.txt", "r", encoding="utf8")
all_text = f.read()
f.close()


lst_w = all_text.split("\n\n")
lst_af_all = []
for i in range(len(lst_w)):
    try:
        lst_af = []
        s = lst_w[i].split("\n")
        lst_af.append(s[0][1:])
        for i in range(1, len(s)):
            if s[i][0] == "=":
                s[i] = s[i].replace("=", "Example: ", 1)
                s[i] = s[i].replace("+", " = ")
            elif s[i][0] == "!":
                s[i] = s[i].replace("!", "Phrase: ", 1)
        lst_af.append("\n".join(s[1:]))
        lst_af_all.append(lst_af)
    except:
        print("---Lỗi gì đó---")

print(len(lst_w), len(lst_af_all))

def insert():
    path = "./TuDien.db"
    con = lite.connect(path)

    sql = """INSERT INTO VietAnh VALUES(?, ?)"""

    for i in range(len(lst_af_all)):
        cur = con.cursor()
        try:
            cur.execute(sql, (lst_af_all[i][0], lst_af_all[i][1]))
        except:
            print("---Lỗi gì đó---")
        cur.close()
    con.commit()
    con.close()

def print():
    path = "./TuDien.db"
    con = lite.connect(path)
    sql = """SELECT * FROM VietAnh"""
    cur = con.cursor()
    cur.execute(sql)
    rows = cur.fetchall()
    cur.close()
    con.commit()
    con.close()
    print(rows)

def delete():
    path = "./TuDien.db"
    con = lite.connect(path)
    sql = """DELETE FROM VietAnh"""
    cur = con.cursor()
    cur.execute(sql)
    cur.close()
    con.commit()
    con.close()


if __name__=="__main__":
    insert()