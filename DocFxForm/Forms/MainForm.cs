namespace DocFxForm
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// ������ �ִ� docfx �ֽ� ����
		/// </summary>
		FileInfo? m_fiDocFxLastVer = null;

		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//���� �ε�Ǹ� docfx�� �ִ��� Ȯ���Ѵ�.
			this.CheckDocFx();
		}

		/// <summary>
		/// docfx�� �ٿ�ε� �Ǿ��ִ��� Ȯ��
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void CheckDocFx()
		{
			//�˻��� ���丮 ����
			DirectoryInfo findDI
				= new DirectoryInfo("DocFX");

			//������ �ֳ� Ȯ��(������)
			DirectoryInfo[] findDIs = findDI.GetDirectories();

			if (0 < findDIs.Length)
			{
				//DocFX�� �����Ƿ� �����Ҽ� ����.
				throw new Exception();
			}
			else
			{
				//�ֽŹ����� ���� �˻��ϱ����� �̸� �������� ����
				findDIs
					= findDI.GetDirectories()
						.OrderByDescending(o => o.Name)
						.ToArray();

				//ã�Ҵ��� ����
				bool bFind = false;

				//������ "docfx.exe"�� �ֳ� Ȯ��
				foreach (DirectoryInfo itemDI in findDIs)
				{
					//"docfx.exe" �������� ã��
					FileInfo? findFiles = itemDI.GetFiles("docfx.exe").FirstOrDefault();
					if (null != findFiles)
					{//ã�Ҵ�!
						bFind = true;
						//ã�� ��ü ����
						this.m_fiDocFxLastVer = findFiles;
					}

				}//end foreach itemDI

				if (false == bFind)
				{
					//DocFX�� �����Ƿ� �����Ҽ� ����.
					//
					throw new Exception();
				}
			}//end if	
		}

		
	}
}