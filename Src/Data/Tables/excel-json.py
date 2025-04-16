import pandas as pd
import json

def excel_to_json_txt(excel_path, txt_path):
    # 读取Excel数据
    df = pd.read_excel(
        excel_path,
        sheet_name='Elements',
        header=2,
        keep_default_na=False
    )
    
    # 构建字典结构
    result = {}
    for _, row in df.iterrows():
        entry = {
            "TID": int(row["TID"]),
            "Name": row["Name"],
            "Type": row["Type"],
            "Class": row["Class"],
            "Master": row["Master"],
            "Autorotation": float(row["Autorotation"]),
            "Revolution": float(row["Revolution"])
        }
        # 清理空描述字段
        if str(row["Description"]).strip() not in ["", "-"]:
            entry["Description"] = row["Description"]
        
        result[str(row["Key"])] = entry
    
    # 生成带格式的JSON文本
    json_str = json.dumps(
        result,
        ensure_ascii=False,
        indent=2,
        default=str
    )
    
    # 写入TXT文件（实际是标准JSON格式）
    with open(txt_path, 'w', encoding='utf-8') as f:
        f.write(json_str)

# 执行转换
excel_to_json_txt("PlanetDefine.xlsx", "PlanetDefine.txt")