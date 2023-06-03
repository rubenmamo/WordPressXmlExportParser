﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressXmlExportParser.UnitTests
{
    [TestFixture]
    public class CategoryExtractorTests
    {
		[Test]
		public void ExtractsCorrectAmountOfCategories()
		{
            var categories = CategoryExtractor.ExtractCategories(XElement.Parse(xml));

            categories.Count.Should().Be(2);
        }

		[Test]
		public void CorrectlyExtractsTermId()
        {
            var categories = CategoryExtractor.ExtractCategories(XElement.Parse(xml));

            categories[0].Id.Should().Be(2);
            categories[1].Id.Should().Be(5);
        }

        [Test]
        public void CorrectlyExtractsNiceName()
        {
            var categories = CategoryExtractor.ExtractCategories(XElement.Parse(xml));

            categories[0].NiceName.Should().Be("blogging");
            categories[1].NiceName.Should().Be("how-tos");
        }

        [Test]
        public void CorrectlyExtractsParentCategory()
        {
            var categories = CategoryExtractor.ExtractCategories(XElement.Parse(xml));

            categories[0].ParentCategoryName.Should().Be("rootCatgory");
            categories[1].ParentCategoryName.Should().Be(string.Empty);
        }

        [Test]
        public void CorrectlyExtractsName()
        {
            var categories = CategoryExtractor.ExtractCategories(XElement.Parse(xml));

            categories[0].Name.Should().Be("Blogging");
            categories[1].Name.Should().Be("How to's");
        }

        private string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<channel
	xmlns:excerpt=""http://wordpress.org/export/1.2/excerpt/""
	xmlns:content=""http://purl.org/rss/1.0/modules/content/""
	xmlns:wfw=""http://wellformedweb.org/CommentAPI/""
	xmlns:dc=""http://purl.org/dc/elements/1.1/""
	xmlns:wp=""http://wordpress.org/export/1.2/""
>
	<wp:category>
		<wp:term_id>2</wp:term_id>
		<wp:category_nicename><![CDATA[blogging]]></wp:category_nicename>
		<wp:category_parent><![CDATA[rootCatgory]]></wp:category_parent>
		<wp:cat_name><![CDATA[Blogging]]></wp:cat_name>
	</wp:category>
	<wp:category>
		<wp:term_id>5</wp:term_id>
		<wp:category_nicename><![CDATA[how-tos]]></wp:category_nicename>
		<wp:category_parent><![CDATA[]]></wp:category_parent>
		<wp:cat_name><![CDATA[How to's]]></wp:cat_name>
	</wp:category>
</channel>";
    }
}