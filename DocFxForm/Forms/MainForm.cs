namespace DocFxForm
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// 가지고 있는 docfx 최신 버전
		/// </summary>
		FileInfo? m_fiDocFxLastVer = null;

		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//폼이 로드되면 docfx가 있는지 확인한다.
			this.CheckDocFx();
		}

		/// <summary>
		/// docfx가 다운로드 되어있는지 확인
		/// </summary>
		/// <exception cref="Exception"></exception>
		private void CheckDocFx()
		{
			//검사할 디랙토리 지정
			DirectoryInfo findDI
				= new DirectoryInfo("DocFX");

			//폴더가 있나 확인(정렬을)
			DirectoryInfo[] findDIs = findDI.GetDirectories();

			if (0 < findDIs.Length)
			{
				//DocFX이 없으므로 진행할수 없다.
				throw new Exception();
			}
			else
			{
				//최신버전을 먼저 검색하기위해 이름 역순으로 정렬
				findDIs
					= findDI.GetDirectories()
						.OrderByDescending(o => o.Name)
						.ToArray();

				//찾았는지 여부
				bool bFind = false;

				//폴더에 "docfx.exe"가 있나 확인
				foreach (DirectoryInfo itemDI in findDIs)
				{
					//"docfx.exe" 실행파일 찾기
					FileInfo? findFiles = itemDI.GetFiles("docfx.exe").FirstOrDefault();
					if (null != findFiles)
					{//찾았다!
						bFind = true;
						//찾은 개체 저장
						this.m_fiDocFxLastVer = findFiles;
					}

				}//end foreach itemDI

				if (false == bFind)
				{
					//DocFX이 없으므로 진행할수 없다.
					//
					throw new Exception();
				}
			}//end if	
		}

		
	}
}